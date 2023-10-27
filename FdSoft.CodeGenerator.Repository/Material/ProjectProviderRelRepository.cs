using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Dto;
using SqlSugar;
using FdSoft.CodeGenerator.Model;
using Google.Protobuf;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 项目和供应商关系表仓储
    ///
    /// @author admin
    /// @date 2022-11-29
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class ProjectProviderRelRepository : BaseRepository<ProjectProviderRel>
    {
        #region 业务逻辑代码
        public (List<ProjectProviderRelDto>, int) Query(ProjectProviderRelQueryDto query)
        {
            var total = 0;
            var dbList = Context.Queryable<MaterialProvider, ProjectProviderRel>((a, b) => new JoinQueryInfos(JoinType.Inner, a.ProviderId == b.ProviderId))
                .Where((a, b) => b.ProId == query.ProId)
                .WhereIF(!string.IsNullOrEmpty(query.Keyword), (a, b) => a.UsciCode.Contains(query.Keyword) || a.ProviderName.Contains(query.Keyword))
                .Select((a, b) => new ProjectProviderRelDto()
                {
                    RelId = b.RelId,
                    ProviderName = a.ProviderName,
                    UsciCode = a.UsciCode

                }).ToPageList(query.PageNum, query.PageSize, ref total);
            return (dbList, total);
        }

        public (List<ProjectProviderRelDto>, int) QueryOpen(ProjectProviderRelQueryDto query)
        {
            var total = 0;
            var dbList = Context.Queryable<MaterialProvider, ProjectProviderRel>((a, b) => new JoinQueryInfos(JoinType.Left, a.ProviderId == b.ProviderId && b.ProId == query.ProId))
                .Where(a=>a.DeleteStatus==0)
                .Where((a, b) => a.CoId == query.RootCoId && b.ProviderId == null)
                .WhereIF(!string.IsNullOrEmpty(query.Keyword), (a, b) => a.UsciCode.Contains(query.Keyword) || a.ProviderName.Contains(query.Keyword))
                .Select((a, b) => new ProjectProviderRelDto()
                {
                    RelId = b.RelId,
                    ProId = b.ProId,
                    ProviderId = a.ProviderId,
                    ProviderName = a.ProviderName,
                    UsciCode = a.UsciCode

                }).ToPageList(query.PageNum, query.PageSize, ref total);
            return (dbList, total);
        }
        #endregion
    }
}