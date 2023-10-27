using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Dto.Base;
using FdSoft.CodeGenerator.Model.System.Dto;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 企业、项目信息表，包含关联层级service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCCorporationService : IBaseService<JCCorporation>
    {
        List<CorpMemoryDto> GetSonCorpList(LoginBodyDtoNew dtoNew, List<int> productIds, List<CorpMemoryDto> dbCorpList = default, bool isAdmin = false);

        List<CorpTreeDto> GetHomeTree(LoginBodyDtoNew dtoNew, List<CorpMemoryDto> dbCorpList = default, bool isAdmin = false);

        List<CorpMemoryDto> GetCorpList();

        List<CorpMemoryDto> GetCorpListByUserId(LoginBodyDtoNew dtoNew, bool isAdmin = false);

        List<CorpMemoryDto> GetHomeParentTree(int userId, string itemPath);

        List<CorpTreeDto> GetHomeDeepTree(List<CorpTreeDto> allList);

        PagedInfo<JCCorporation> GetList(JCCorporationQueryDto parm);

        int AddJCCorporation(JCCorporation parm);

        int UpdateJCCorporation(JCCorporation parm);

        void TruncateJCCorporation();
        CoIdProjectDto GetProjectInfoByCoId(string coId);
        JCCorporation GetCorporationInfoByProId(string ProId);
    }
}
