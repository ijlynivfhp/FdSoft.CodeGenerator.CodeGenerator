using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Repository.System;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Dto.Base;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 角色信息Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCRoleService), ServiceLifetime = LifeTime.Transient)]
    public class JCRoleService : BaseService<JCRole>, IJCRoleService
    {
        private readonly JCRoleRepository jCRoleRepository;
        public JCRoleService(JCRoleRepository jCRoleRepository)
        {
            this.jCRoleRepository = jCRoleRepository;
        }
        #region 扩展业务代码
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> SelectUserRoleListByUserIdNew(int userId,int productId,string itemPath)
        {
            return jCRoleRepository.SelectUserRoleListByUserIdNew(userId,productId,itemPath);
        }
        #endregion

        #region 业务逻辑代码

        /// <summary>
        /// 查询角色信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCRole> GetList(JCRoleQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCRole>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCRole(JCRole parm)
        {
            var response = Insert(parm, it => new
            {
                it.ParentId,
                it.Status,
                it.ItemPath,
                it.RoleName,
                it.PowerCode,
                it.RoleType,
                it.NodeType,
                it.ProductId,
                it.Remark,
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
        /// 修改角色信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCRole(JCRole parm)
        {
            var response = Update(w => w.RoleId == parm.RoleId, it => new JCRole()
            {
                ParentId = parm.ParentId,
                Status = parm.Status,
                ItemPath = parm.ItemPath,
                RoleName = parm.RoleName,
                PowerCode = parm.PowerCode,
                RoleType = parm.RoleType,
                NodeType = parm.NodeType,
                ProductId = parm.ProductId,
                Remark = parm.Remark,
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
        /// 清空角色信息
        /// </summary>
        /// <returns></returns>
        public void TruncateJCRole()
        {
            Truncate();
        }
        #endregion
    }
}