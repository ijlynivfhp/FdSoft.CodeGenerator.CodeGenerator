using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.System.Vo;
using System.Linq;
using FdSoft.CodeGenerator.Model.Dto.Base;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Common.Enums;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using FdSoft.CodeGenerator.Model.System.Dto;
using OfficeOpenXml.Drawing.Chart.ChartEx;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 企业、项目信息表，包含关联层级Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCCorporationService), ServiceLifetime = LifeTime.Transient)]
    public class JCCorporationService : BaseService<JCCorporation>, IJCCorporationService
    {
        #region 扩展业务代码
        /// <summary>
        /// 判断是否有切换项目或企业的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<CorpMemoryDto> GetSonCorpList(LoginBodyDtoNew dtoNew, List<int> productIds, List<CorpMemoryDto> dbCorpList = default, bool isAdmin = false)
        {
            productIds = productIds ?? new List<int>();
            var coId = dtoNew.SwitchType == 2 ? default : dtoNew.CoId;
            var corpMemoryDtoList = new ConcurrentBag<CorpMemoryDto>();
            try
            {
                var dbRoleCorpList = Context.Ado.SqlQuery<CorpMemoryDto>($@"SELECT DISTINCT
                       ur.CoId,
                       r.ProductId,
                       p.OrganizeType
                FROM dbo.JC_UserRole ur
                    INNER JOIN dbo.JC_Role r
                        ON ur.RoleId = r.RoleId
                           AND ur.DeleteStatus = 0
                           AND r.DeleteStatus = 0 {(productIds.Count > 0 ? $"AND r.ProductId IN ({string.Join(",", productIds)})" : default)}
                    INNER JOIN dbo.JC_Product p
                        ON r.ProductId = p.ProductCode
                           AND p.DeleteStatus = 0
                           AND p.Status = 1
                           AND p.ProductType = {dtoNew.ProductType}
                WHERE ur.UserId = {dtoNew.UserId}");

                if (dbCorpList is null) dbCorpList = GetCorpListByUserId(dtoNew, isAdmin);

                dbRoleCorpList.AsParallel().ForAll(o =>
                {
                    var corpList = dbCorpList.Where(p => p.ItemPath.IsNotEmpty() && p.ItemPath.Split(",").Select(int.Parse).Contains(o.CoId)).ToList();
                    corpList.AsParallel().ForAll(p =>
                    {
                        corpMemoryDtoList.Add(new CorpMemoryDto()
                        {
                            CoId = p.CoId,
                            ParentCoId = p.ParentCoId,
                            ProId = p.ProId,
                            ItemPath = p.ItemPath,
                            CoName = p.CoName,
                            CoType = p.CoType,
                            RootCoId = p.RootCoId,
                            ProductId = o.ProductId,
                            OrganizeType = o.OrganizeType,
                            Status = p.Status
                        });
                    });
                });

                if (coId > 0) corpMemoryDtoList = new ConcurrentBag<CorpMemoryDto>(corpMemoryDtoList.Where(o => o.ItemPath.Split(",").Select(int.Parse).Contains(coId)));
            }
            catch { }
            var dataList = corpMemoryDtoList.DistinctBy(o => new { o.CoId, o.ParentCoId, o.ProId, o.ItemPath, o.CoName, o.CoType, o.RootCoId, o.ProductId, o.OrganizeType, o.Status }).ToList();

            if (!isAdmin && dtoNew.ProductType == (int)ProductType.Old)
            {
                var topCorpList = dataList.Where(o => o.CoType != 1).ToList();
                for (int i = 0; i < topCorpList.Count; i++)
                {
                    if (!dataList.Any(o => o.ItemPath.StartsWith(topCorpList[i].ItemPath) && o.ItemPath != topCorpList[i].ItemPath))
                        dataList.RemoveAll(o => o.CoId == topCorpList[i].CoId);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 获取树形所需基础数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<CorpTreeDto> GetHomeTree(LoginBodyDtoNew dtoNew, List<CorpMemoryDto> dbCorpList = default, bool isAdmin = false)
        {
            var corpMemoryDtoList = new ConcurrentBag<CorpTreeDto>();
            try
            {
                var dbRoleCorpList = Context.Ado.SqlQuery<CorpMemoryDto>($@"
                SELECT DISTINCT ur.CoId   
                    FROM dbo.JC_UserRole ur
                        INNER JOIN dbo.JC_Role r
                            ON ur.RoleId = r.RoleId AND ur.DeleteStatus = 0 AND r.DeleteStatus = 0 AND ur.UserId = {dtoNew.UserId} ");

                if (dbCorpList is null) dbCorpList = GetCorpListByUserId(dtoNew, isAdmin);

                dbRoleCorpList.AsParallel().ForAll(o =>
                {
                    var corp = dbCorpList.First(p => p.CoId == o.CoId);
                    var corpList = dbCorpList.Where(p => (p.ItemPath.IsNotEmpty() && p.ItemPath.Split(",").Select(int.Parse).Contains(o.CoId)) || (corp.ItemPath.IsNotEmpty() && corp.ItemPath.Split(",").Select(int.Parse).Contains(p.CoId))).ToList();
                    corpList.AsParallel().ForAll(p =>
                    {
                        corpMemoryDtoList.Add(new CorpTreeDto()
                        {
                            CoId = p.CoId,
                            ParentCoId = p.ParentCoId,
                            ProId = p.ProId,
                            ItemPath = p.ItemPath,
                            CoName = p.CoName,
                            CoType = p.CoType,

                        });
                    });
                });
            }
            catch { }
            var dataList = corpMemoryDtoList.DistinctBy(o => new { o.CoId, o.ParentCoId, o.ProId, o.ItemPath, o.CoName, o.CoType }).ToList();
            if (!isAdmin && dtoNew.ProductType == (int)ProductType.Old)
            {
                var topCorpList = dataList.Where(o => o.CoType != 1).ToList();
                for (int i = 0; i < topCorpList.Count; i++)
                {
                    if (!dataList.Any(o => o.ItemPath.StartsWith(topCorpList[i].ItemPath) && o.ItemPath != topCorpList[i].ItemPath))
                        dataList.RemoveAll(o => o.CoId == topCorpList[i].CoId);
                }
            }
            return dataList.GroupBy(o => new { o.CoId, o.ParentCoId, o.ProId, o.ItemPath, o.CoName, o.CoType }).Select(o => o.First()).OrderBy(o => o.CoId).ToList();
        }

        /// <summary>
        /// 获取所有的项目或企业
        /// </summary>
        /// <returns></returns>
        public List<CorpMemoryDto> GetCorpList()
        {
            return Context.Ado.SqlQuery<CorpMemoryDto>($@"SELECT CoId,
                        ParentCoId,
                        ProId,
                        ItemPath,
                        CoName,
                        CoType,
                        RootCoId
                FROM dbo.JC_Corporation
                WHERE DeleteStatus = 0;").ToList();
        }

        /// <summary>
        /// 根据用户获取所有的项目或企业
        /// </summary>
        /// <returns></returns>
        public List<CorpMemoryDto> GetCorpListByUserId(LoginBodyDtoNew dtoNew, bool isAdmin = false)
        {
            var dbList = Context.Ado.SqlQuery<CorpMemoryDto>($@"SELECT DISTINCT
                   subCorp.CoId,
                   subCorp.ParentCoId,
                   subCorp.ProId,
                   subCorp.ItemPath,
                   subCorp.CoName,
                   subCorp.CoType,
                   subCorp.RootCoId,
                   p.Status
            FROM dbo.JC_Corporation topCorp
                INNER JOIN dbo.JC_Corporation subCorp
                    ON topCorp.RootCoId = subCorp.RootCoId
                LEFT JOIN dbo.JC_Project p
                    ON subCorp.ProId = p.ProId
                       AND p.DeleteStatus = 0
            WHERE EXISTS
            (
                SELECT DISTINCT
                       CoId
                FROM dbo.JC_UserRole
                WHERE UserId = {dtoNew.UserId}
                      AND DeleteStatus = 0
                      AND CoId = topCorp.CoId
            )
                  AND topCorp.DeleteStatus = 0
                  AND subCorp.DeleteStatus = 0").ToList();
            if (!isAdmin) dbList.RemoveAll(o => o.Status == 2);
            return dbList;
        }

        /// <summary>
        /// 获取父级树形所需基础数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<CorpMemoryDto> GetHomeParentTree(int userId, string itemPath)
        {
            try
            {
                return Context.Ado.SqlQuery<CorpMemoryDto>($@"
                WITH ups
                AS (SELECT DISTINCT corp.CoId,corp.ParentCoId,corp.DeleteStatus,corp.ProId,corp.ItemPath,corp.CoName,corp.CoType,corp.RootCoId,r.ProductId,p.OrganizeType 
                    FROM dbo.JC_UserRole ur
                        INNER JOIN dbo.JC_Corporation corp
                            ON ur.CoId = corp.CoId AND corp.DeleteStatus = 0 AND ur.UserId = {userId} 
                        INNER JOIN dbo.JC_Role r
                            ON ur.RoleId = r.RoleId AND ur.DeleteStatus = 0 AND r.DeleteStatus = 0 
                        INNER JOIN dbo.JC_Product p ON r.ProductId = p.ProductCode AND p.DeleteStatus = 0 AND p.Status = 1 
                    UNION ALL
                    SELECT corp.CoId,corp.ParentCoId,corp.DeleteStatus,corp.ProId,corp.ItemPath,corp.CoName,corp.CoType,corp.RootCoId,ups.ProductId,ups.OrganizeType 
                    FROM ups
                        INNER JOIN dbo.JC_Corporation corp
                            ON ups.ParentCoId = corp.CoId AND corp.DeleteStatus = 0)
                SELECT DISTINCT ups.CoId,ups.ParentCoId,ups.ProId,ups.ItemPath,ups.CoName,ups.CoType,ups.RootCoId,ups.ProductId,ups.OrganizeType 
                FROM ups WHERE 1=1 {(itemPath.IsNotEmpty() ? $"AND ups.CoId IN (SELECT value FROM STRING_SPLIT('{itemPath}', ','))" : string.Empty)} 
                OPTION (MAXRECURSION 0)").ToList();
            }
            catch
            {
                return new List<CorpMemoryDto>();
            }
        }

        /// <summary>
        /// 获取子级树形所需基础数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<JCCorporation> GetHomeSonTree(int userId, int productId, int coId = default)
        {
            try
            {
                return Context.Ado.SqlQuery<JCCorporation>($@"
                WITH downs
                AS (SELECT DISTINCT corp.*
                    FROM dbo.JC_UserRole ur
                        INNER JOIN dbo.JC_Corporation corp
                            ON ur.CoId = corp.CoId AND corp.DeleteStatus = 0 AND ur.UserId = {userId} 
                        INNER JOIN dbo.JC_Role r
                            ON ur.RoleId = r.RoleId 
                               AND r.ProductId = {productId} AND ur.DeleteStatus = 0 AND r.DeleteStatus = 0
                    UNION ALL
                    SELECT corp.*
                    FROM downs
                        INNER JOIN dbo.JC_Corporation corp
                            ON corp.ParentCoId = downs.CoId AND corp.DeleteStatus = 0),
                     ups
                AS (SELECT DISTINCT corp.*
                    FROM dbo.JC_UserRole ur
                        INNER JOIN dbo.JC_Corporation corp
                            ON ur.CoId = corp.CoId AND corp.DeleteStatus = 0  AND ur.UserId = {userId} 
                        INNER JOIN dbo.JC_Role r
                            ON ur.RoleId = r.RoleId
                               AND r.ProductId = {productId} AND ur.DeleteStatus = 0 AND r.DeleteStatus = 0
                    UNION ALL
                    SELECT corp.*
                    FROM ups
                        INNER JOIN dbo.JC_Corporation corp
                            ON ups.ParentCoId = corp.CoId AND corp.DeleteStatus = 0)
                SELECT DISTINCT *
                FROM ups WHERE 1=1 {(coId > 0 ? $"AND {coId} IN (SELECT value FROM STRING_SPLIT(ups.ItemPath, ','))" : string.Empty)} 
                UNION
                SELECT DISTINCT *
                FROM downs WHERE 1=1 {(coId > 0 ? $"AND {coId} IN (SELECT value FROM STRING_SPLIT(downs.ItemPath, ','))" : string.Empty)} 
                OPTION (MAXRECURSION 0)").ToList();
            }
            catch
            {
                return new List<JCCorporation>();
            }
        }

        /// <summary>
        /// 转换树形数据
        /// </summary>
        /// <returns></returns>
        public List<CorpTreeDto> GetHomeDeepTree(List<CorpTreeDto> allList)
        {

            var topList = allList.Where(o => o.ParentCoId == 0).ToList();

            return GetHomeDeepTreeData(topList, allList);

            List<CorpTreeDto> GetHomeDeepTreeData(List<CorpTreeDto> topList, List<CorpTreeDto> allList)
            {
                if (allList is null || allList.Count == 0 || topList is null || topList.Count == 0) return new List<CorpTreeDto>();
                topList.ForEach(o =>
                {
                    var tempChildren = allList.Where(p => p.ParentCoId == o.CoId).ToList();
                    o.Children = tempChildren;
                    allList.RemoveAll(o => tempChildren.Contains(o));
                    if (o.Children.Count > 0)
                        GetHomeDeepTreeData(o.Children, allList);
                });
                return topList;
            }
        }
        #endregion

        #region 业务逻辑代码

        /// <summary>
        /// 查询企业、项目信息表，包含关联层级列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCCorporation> GetList(JCCorporationQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCCorporation>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加企业、项目信息表，包含关联层级
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCCorporation(JCCorporation parm)
        {
            var response = Insert(parm, it => new
            {
                it.ParentCoId,
                it.RootCoId,
                it.ItemPath,
                it.Status,
                it.CoType,
                it.CoName,
                it.CorpCode,
                it.AreaCode,
                it.ProId,
                it.ContactMan,
                it.ContactManTel,
                it.LegalMan,
                it.LegalManTel,
                it.UnitLevel,
                it.UnitPhone,
                it.Fax,
                it.WebUrl,
                it.Address,
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
        /// 修改企业、项目信息表，包含关联层级
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCCorporation(JCCorporation parm)
        {
            var response = Update(w => w.CoId == parm.CoId, it => new JCCorporation()
            {
                ParentCoId = parm.ParentCoId,
                RootCoId = parm.RootCoId,
                ItemPath = parm.ItemPath,
                Status = parm.Status,
                CoType = parm.CoType,
                CoName = parm.CoName,
                CorpCode = parm.CorpCode,
                AreaCode = parm.AreaCode,
                ProId = parm.ProId,
                ContactMan = parm.ContactMan,
                ContactManTel = parm.ContactManTel,
                LegalMan = parm.LegalMan,
                LegalManTel = parm.LegalManTel,
                UnitLevel = parm.UnitLevel,
                UnitPhone = parm.UnitPhone,
                Fax = parm.Fax,
                WebUrl = parm.WebUrl,
                Address = parm.Address,
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
        /// 清空企业、项目信息表，包含关联层级
        /// </summary>
        /// <returns></returns>
        public void TruncateJCCorporation()
        {
            Truncate();
        }
        #endregion
        public CoIdProjectDto GetProjectInfoByCoId(string coId)
        {
            var dt = Context.Ado.SqlQuery<CoIdProjectDto>(@$"select  ProId,ProName from JC_Project where ProId in (select ProId from JC_Corporation where CoId='{coId}' and CoType='1' ) ").FirstOrDefault();
            return dt;
        }

        public JCCorporation GetCorporationInfoByProId(string ProId)
        {
          return  Context.Ado.SqlQuery<JCCorporation>($@"select [CoId]
                                                      ,[ParentCoId]
                                                      ,[RootCoId]
                                                      ,[ItemPath]
                                                      ,[Status]
                                                      ,[CoType]
                                                      ,[CoName]
                                                      ,[CorpCode]
                                                      ,[AreaCode]
                                                      ,[ProId]
                                                      ,[ContactMan]
                                                      ,[ContactManTel]
                                                      ,[LegalMan]
                                                      ,[LegalManTel]
                                                      ,[UnitLevel]
                                                      ,[UnitPhone]
                                                      ,[Fax]
                                                      ,[WebUrl]
                                                      ,[Address]
                                                      ,[Remark]
                                                      ,[CreateUserId]
                                                      ,[LastEditUserId]
                                                      ,[LastEditor]
                                                      ,[Creator]
                                                      ,[DeleteStatus]
                                                      ,[AddTime]
                                                      ,[UpdateTime] from JC_Corporation where CoId in (select ParentCoId from JC_Corporation where ProId='{ProId}')").FirstOrDefault();
        }
    }
}
