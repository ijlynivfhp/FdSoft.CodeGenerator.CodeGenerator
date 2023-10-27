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
    /// 企业项目用户关联信息Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCUserCorporationService), ServiceLifetime = LifeTime.Transient)]
    public class JCUserCorporationService : BaseService<JCUserCorporation>, IJCUserCorporationService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询企业项目用户关联信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCUserCorporation> GetList(JCUserCorporationQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCUserCorporation>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加企业项目用户关联信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCUserCorporation(JCUserCorporation parm)
        {
            var response = Insert(parm, it => new
            {
                it.UserId,
                it.CoId,
                it.RootCoId,
                it.CreateUserId,
                it.LastEditUserId,
                it.Creator,
                it.LastEditor,
                it.DeleteStatus,
                it.AddTime,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改企业项目用户关联信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCUserCorporation(JCUserCorporation parm)
        {
            var response = Update(w => w.UcId == parm.UcId, it => new JCUserCorporation()
            {
                UserId = parm.UserId,
                CoId = parm.CoId,
                RootCoId = parm.RootCoId,
                CreateUserId = parm.CreateUserId,
                LastEditUserId = parm.LastEditUserId,
                Creator = parm.Creator,
                LastEditor = parm.LastEditor,
                DeleteStatus = parm.DeleteStatus,
                AddTime = parm.AddTime,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空企业项目用户关联信息
        /// </summary>
        /// <returns></returns>
        public void TruncateJCUserCorporation()
        {
            Truncate();
        }
        #endregion
    }
}