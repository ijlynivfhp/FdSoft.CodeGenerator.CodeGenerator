using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 用户角色关联表Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCUserRoleService), ServiceLifetime = LifeTime.Transient)]
    public class JCUserRoleService : BaseService<JCUserRole>, IJCUserRoleService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询用户角色关联表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCUserRole> GetList(JCUserRoleQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCUserRole>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加用户角色关联表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCUserRole(JCUserRole parm)
        {
            var response = Insert(parm, it => new
            {
                it.RoleId,
                it.UserId,
                it.CoId,
                it.CreateUserId,
                it.LastEditUserId,
                it.LastEditor,
                it.Creator,
                it.DeleteStatus,
                it.AddTime,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改用户角色关联表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCUserRole(JCUserRole parm)
        {
            var response = Update(w => w.UrId == parm.UrId, it => new JCUserRole()
            {
                RoleId = parm.RoleId,
                UserId = parm.UserId,
                CoId = parm.CoId,
                CreateUserId = parm.CreateUserId,
                LastEditUserId = parm.LastEditUserId,
                LastEditor = parm.LastEditor,
                Creator = parm.Creator,
                DeleteStatus = parm.DeleteStatus,
                AddTime = parm.AddTime,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空用户角色关联表
        /// </summary>
        /// <returns></returns>
        public void TruncateJCUserRole()
        {
            Truncate();
        }
        #endregion
    }
}