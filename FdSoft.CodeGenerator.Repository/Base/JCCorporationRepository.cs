using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;
using SqlSugar;
using System.Linq;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 企业、项目信息表，包含关联层级仓储
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class JCCorporationRepository : BaseRepository<JCCorporation>
    {
        #region 业务逻辑代码
        /// <summary>
        /// 根据用户Id查找关联企业和项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<JCCorporation> GetCorpListByUserId(int userId, int dataType = -1)
        {
            if (dataType == 0)
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                        JoinType.Inner, cr.CoId == c.CoId,
                        JoinType.Inner, cr.UserId == r.UserId
                    )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0 && c.CoType == 0)
                    .Select((cr, c, r) => c).ToList();
            else if (dataType == 1)
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                            JoinType.Inner, cr.CoId == c.CoId,
                            JoinType.Inner, cr.UserId == r.UserId
                        )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0 && c.CoType > 0)
                        .Select((cr, c, r) => c).ToList();
            else
            {
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                        JoinType.Inner, cr.CoId == c.CoId,
                        JoinType.Inner, cr.UserId == r.UserId
                    )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0)
                    .Select((cr, c, r) => c).ToList();
            }

        }

        /// <summary>
        /// 根据用户Id查找关联企业和项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JCCorporation GetFirstCorpByUserId(int userId, int dataType = -1)
        {
            if (dataType == 0)
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                        JoinType.Inner, cr.CoId == c.CoId,
                        JoinType.Inner, cr.UserId == r.UserId
                    )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0 && c.CoType == 0).OrderByDescending((cr, c, r) => c.AddTime)
                    .Select((cr, c, r) => c).First();
            else if (dataType == 1)
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                            JoinType.Inner, cr.CoId == c.CoId,
                            JoinType.Inner, cr.UserId == r.UserId
                        )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0 && c.CoType > 0).OrderByDescending((cr, c, r) => c.AddTime)
                        .Select((cr, c, r) => c).First();
            else
            {
                return Context.Queryable<JCUserCorporation, JCCorporation, JCUser>((cr, c, r) => new JoinQueryInfos(
                        JoinType.Inner, cr.CoId == c.CoId,
                        JoinType.Inner, cr.UserId == r.UserId
                    )).Where((cr, c, r) => cr.UserId == userId && cr.DeleteStatus == 0 && c.DeleteStatus == 0 && r.DeleteStatus == 0).OrderByDescending((cr, c, r) => c.AddTime)
                    .Select((cr, c, r) => c).First();
            }
        }


        public List<JCCorporation> GetCorpListByParentId(List<int?> parentIds, List<JCCorporation> dataList = default)
        {
            dataList = dataList ?? new List<JCCorporation>();
            var getDbList = Context.Queryable<JCCorporation>().Where(o => parentIds.Contains(o.ParentCoId)).ToList();
            if (getDbList != null && getDbList.Count > 0)
            {
                dataList.AddRange(getDbList);
                GetCorpListByParentId(getDbList.Select(o => (int?)o.CoId).ToList(), dataList);
            }
            return dataList;
        }
        #endregion
    }
}