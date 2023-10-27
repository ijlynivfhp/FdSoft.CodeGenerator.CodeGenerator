using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Model.System;
using SqlSugar;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Dto.Base;
using FdSoft.CodeGenerator.Common.Extensions;
using System.Linq;
using FdSoft.CodeGenerator.Model.Dto.Material;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 角色信息仓储
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class JCRoleRepository : BaseRepository<JCRole>
    {
        #region 业务逻辑代码
        /// <summary>
        /// 获取用户所有角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserRoleProductCorpDto> GetProductRoleCorpList(long userId)
        {
            return Context.Queryable<JCUserRole, JCRole>((ur, r) => new JoinQueryInfos(
                JoinType.Left, ur.RoleId == r.RoleId
            )).Where((ur, r) => ur.UserId == userId && ur.DeleteStatus == 0 && r.DeleteStatus == 0)
            .Select((ur, r) => new UserRoleProductCorpDto
            {
                UserId = ur.UserId,
                ProductId = r.ProductId ?? default,
                CoId = ur.CoId,
                RoleId = ur.RoleId,
                PowerCode = r.PowerCode,
            }).Distinct().ToList();
        }

        /// <summary>
        /// 获取用户所有角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> SelectUserRoleListByUserIdNew(long userId, long productId, string itemPath)
        {
            var coIdIds = Context.Ado.SqlQuery<int>($"SELECT CoId FROM dbo.JC_Corporation WHERE CoId in (SELECT value FROM STRING_SPLIT('{itemPath}', ','))");
            return Context.Queryable<JCUserRole, JCRole>((ur, r) => new JoinQueryInfos(
                JoinType.Left, ur.RoleId == r.RoleId
            )).Where((ur, r) => ur.UserId == userId && r.ProductId == productId && ur.DeleteStatus == 0 && r.DeleteStatus == 0 && coIdIds.Contains(ur.CoId))
            .Select((ur, r) => r.PowerCode).ToList();
        }

        /// <summary>
        /// 获取用户所有角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> SelectProductIdListByUserId(long userId)
        {
            return Context.Queryable<JCUserRole, JCRole>((ur, r) => new JoinQueryInfos(
                JoinType.Left, ur.RoleId == r.RoleId
            )).Where((ur, r) => ur.UserId == userId && ur.DeleteStatus == 0 && r.DeleteStatus == 0)
            .Select((ur, r) => r.ProductId ?? default).Distinct().ToList();
        }
        #endregion
    }
}