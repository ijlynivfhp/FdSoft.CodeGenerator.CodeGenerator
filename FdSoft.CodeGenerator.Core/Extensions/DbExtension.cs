using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Helper;
using SqlSugar;
using SqlSugar.IOC;
using System.Reflection;
using FdSoft.CodeGenerator.Model.System;
using Microsoft.Extensions.Configuration;
using FdSoft.CodeGenerator.Core.Framework;

namespace FdSoft.CodeGenerator.Core.Extensions
{
    public static class DbExtension
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //全部数据权限
        public static string DATA_SCOPE_ALL = "1";
        //自定数据权限
        public static string DATA_SCOPE_CUSTOM = "2";
        //部门数据权限
        public static string DATA_SCOPE_DEPT = "3";
        //部门及以下数据权限
        public static string DATA_SCOPE_DEPT_AND_CHILD = "4";
        //仅本人数据权限
        public static string DATA_SCOPE_SELF = "5";

        public static void AddDb(IConfiguration Configuration)
        {
            string connStr = Configuration.GetConnectionString("conn_db");
            string connStr_attendance_monthreport = Configuration.GetConnectionString("conn_db_attendance_monthreport");
            string connStr_attendance_record = Configuration.GetConnectionString("conn_db_attendance_record");
            string connStr_iotsys = Configuration.GetConnectionString("conn_db_iotsys");
            int dbType = Convert.ToInt32(Configuration.GetConnectionString("conn_db_type"));

            SugarIocServices.AddSqlSugar(new List<IocConfig>() {
                   new IocConfig() {
                    ConfigId = "0",//默认db
                    ConnectionString = connStr,
                    DbType = (IocDbType)dbType,
                    IsAutoCloseConnection = true
                },
                   new IocConfig() {
                    ConfigId = "1",
                    ConnectionString = connStr_attendance_monthreport,
                    DbType = (IocDbType)dbType,
                    IsAutoCloseConnection = true
                },
                   new IocConfig() {
                    ConfigId = "2",
                    ConnectionString = connStr_attendance_record,
                    DbType = (IocDbType)dbType,
                    IsAutoCloseConnection = true,
                },
                   new IocConfig() {
                    ConfigId = "3",
                    ConnectionString = connStr_iotsys,
                    DbType = (IocDbType)dbType,
                    IsAutoCloseConnection = true,
                }
                   //...增加其他数据库
                });
            SugarIocServices.ConfigurationSugar(db =>
            {
                //db0数据过滤
                //FilterData(0);

                #region db0
                db.GetConnectionScope(0).Aop.OnLogExecuting = (sql, pars) =>
                {
                    var param = db.GetConnectionScope(0).Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));

                    //logger.Info($"【sql语句】{sql}，{param}\n");
                };

                db.GetConnectionScope(0).Aop.OnError = (e) =>
                {
                    logger.Error(e, $"执行SQL出错：{e.Message}");
                };
                //SQL执行完
                db.GetConnectionScope(0).Aop.OnLogExecuted = (sql, pars) =>
                {
                    //执行完了可以输出SQL执行时间 (OnLogExecutedDelegate) 
                };
                #endregion

                #region db1
                //Db1
                db.GetConnection(1).Aop.OnLogExecuting = (sql, pars) =>
                {
                    var param = db.GetConnection(1).Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));

                    //logger.Info($"【sql语句】{sql}, {param}");
                };
                //Db1错误日志
                db.GetConnection(1).Aop.OnError = (e) =>
                {
                    logger.Error($"执行Sql语句失败：{e.Sql}，原因：{e.Message}");
                };
                #endregion
            });

        }

        /// <summary>
        /// 初始化db
        /// </summary>
        /// <param name="service"></param>
        public static void InitDb(this IServiceProvider service)
        {
            var db = DbScoped.SugarScope;
            db.DbMaintenance.CreateDatabase();
            //db.CodeFirst.

            var baseType = typeof(SysBase);
            var entityes = AssemblyUtils.GetAllTypes().Where(p => !p.IsAbstract && p != baseType && /*p.IsAssignableTo(baseType) && */p.GetCustomAttribute<SugarTable>() != null).ToArray();
            db.CodeFirst.SetStringDefaultLength(512).InitTables(entityes);
        }

        /// <summary>
        /// 数据过滤
        /// </summary>
        /// <param name="configId">多库id</param>
        private static void FilterData(int configId)
        {
            var u = App.User;
            if (u == null) return;
            //获取当前用户的信息
            var user = JwtUtil.GetLoginUser(App.HttpContext);
            if (user == null) return;
            //管理员不过滤
            if (user.RoleIds.Any(f => f.Equals("admin"))) return;
            var db = DbScoped.SugarScope.GetConnectionScope(configId);
            foreach (var role in user.Roles.OrderBy(f => f.DataScope))
            {
                string dataScope = role.DataScope;
                if (DATA_SCOPE_ALL.Equals(dataScope))//所有权限
                {
                    break;
                }
                else if (DATA_SCOPE_CUSTOM.Equals(dataScope))//自定数据权限
                {
                    //" OR {}.dept_id IN ( SELECT dept_id FROM sys_role_dept WHERE role_id = {} ) ", deptAlias, role.getRoleId()));
                    var filter1 = new TableFilterItem<SysUser>(it => SqlFunc.Subqueryable<SysRoleDept>().Where(f => f.DeptId == it.DeptId && f.RoleId == role.RoleId).Any());
                    db.QueryFilter.Add(filter1);
                }
                else if (DATA_SCOPE_DEPT.Equals(dataScope))//本部门数据
                {
                    var filter1 = new TableFilterItem<SysUser>(it => it.DeptId == user.DeptId);
                    db.QueryFilter.Add(filter1);
                }
                else if (DATA_SCOPE_DEPT_AND_CHILD.Equals(dataScope))//本部门及以下数据
                {
                    //SQl  OR {}.dept_id IN ( SELECT dept_id FROM sys_dept WHERE dept_id = {} or find_in_set( {} , ancestors ) )
                    var allChildDepts = db.Queryable<SysDept>().ToChildList(it => it.ParentId, user.DeptId);

                    var filter1 = new TableFilterItem<SysUser>(it => allChildDepts.Select(f => f.DeptId).ToList().Contains(it.DeptId));
                    db.QueryFilter.Add(filter1);

                    var filter2 = new TableFilterItem<SysDept>(it => allChildDepts.Select(f => f.DeptId).ToList().Contains(it.DeptId));
                    db.QueryFilter.Add(filter2);
                }
                else if (DATA_SCOPE_SELF.Equals(dataScope))//仅本人数据
                {
                    var filter1 = new TableFilterItem<SysUser>(it => it.UserId == user.UserId, true);
                    db.QueryFilter.Add(filter1);
                }
            }
        }
    }
}
