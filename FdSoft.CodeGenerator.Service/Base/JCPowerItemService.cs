using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using FdSoft.CodeGenerator.Model.System.Vo;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using SqlSugar.Extensions;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Common.Extensions;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 角色菜单Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCPowerItemService), ServiceLifetime = LifeTime.Transient)]
    public class JCPowerItemService : BaseService<JCPowerItem>, IJCPowerItemService
    {
        #region 扩展逻辑代码

        /// <summary>
        /// 获取用户菜单数据
        /// </summary>
        /// <param name="proIds"></param>
        /// <returns></returns>
        public List<SysMenu> GetPowerItemTreeData(List<JCPowerItem> baseAllList)
        {
            if (baseAllList.Count == 0) return new List<SysMenu>();
            var topProduct = baseAllList.FirstOrDefault(o => o.ParentId == 0);
            var topPowerList = baseAllList.Where(o => o.ParentId == topProduct?.ItemId && new int?[] { 1, 5 }.Contains(o.ItemType)).ToList();
            var topRouterList = topPowerList.Select(o => ConvertToRouterVO(o, true)).ToList();
            var treeData = GetPowerItemDeepData((topPowerList, topRouterList), baseAllList);
            return treeData.Item2;
        }
        private (List<JCPowerItem>, List<SysMenu>) GetPowerItemDeepData((List<JCPowerItem>, List<SysMenu>) topList, List<JCPowerItem> allList)
        {
            if (allList is null || allList.Count == 0) return (new List<JCPowerItem>(), new List<SysMenu>());
            if (topList.Item1 is null || topList.Item1.Count == 0) return (new List<JCPowerItem>(), new List<SysMenu>());
            for (int i = 0; i < topList.Item1.Count; i++)
            {
                var tempCorp = topList.Item1[i];
                var tempRouter = topList.Item2[i];
                var tempCorpChildrens = allList.Where(p => p.ParentId == tempCorp.ItemId).ToList();
                var tempRouterChildrens = tempCorpChildrens.Select(o => ConvertToRouterVO(o)).ToList();
                tempCorp.Children = tempCorpChildrens;
                tempRouter.Children = tempRouterChildrens;
                allList.RemoveAll(o => tempCorpChildrens.Any(p => p.ItemId == o.ItemId));
                if (tempCorpChildrens.Count > 0)
                {
                    GetPowerItemDeepData((tempCorpChildrens, tempRouterChildrens), allList);
                }
            }
            return topList;
        }
        private SysMenu ConvertToRouterVO(JCPowerItem jCPowerItem, bool reSetParentId = default)
        {
            var sysmenu = new SysMenu()
            {
                MenuId = jCPowerItem.ItemId,
                MenuName = jCPowerItem.ItemName,
                ParentId = reSetParentId ? default : jCPowerItem.ParentId.ParseToLong(),
                OrderNum = jCPowerItem.OrderId.ObjToInt(),
                Path = (jCPowerItem.ItemUrlLike ?? String.Empty).Trim('/').ToLower(),
                IsFrame = "0",
                IsCache = "0",
                Component = (jCPowerItem.ItemValue ?? String.Empty).Trim('/').ToLower(),
                Status = jCPowerItem.DeleteStatus.HasValue && jCPowerItem.DeleteStatus == 1 ? "1" : "0",
                Visible = "0",
                Icon = jCPowerItem.ItemIcon1 ?? jCPowerItem.ItemIcon2,
            };

            switch (jCPowerItem.ItemType)
            {
                case 1:
                    sysmenu.MenuType = "C";
                    break;
                case 2:
                    sysmenu.MenuType = "L";
                    break;
                case 3:
                    sysmenu.MenuType = "F";
                    break;
                case 4:
                    sysmenu.MenuType = "A";
                    break;
                case 5:
                    sysmenu.MenuType = "M";
                    break;
                default:
                    sysmenu.MenuType = "M";
                    break;
            }

            return sysmenu;
        }
        #endregion

        #region 业务逻辑代码

        /// <summary>
        /// 查询角色菜单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCPowerItem> GetList(JCPowerItemQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCPowerItem>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCPowerItem(JCPowerItem parm)
        {
            var response = Insert(parm, it => new
            {
                it.ParentId,
                it.ItemName,
                it.ItemCode,
                it.ItemPath,
                it.ItemType,
                it.InheritType,
                it.ItemValue,
                it.ProductId,
                it.ItemUrlLike,
                it.PowerCode,
                it.OrderId,
                it.ItemIcon1,
                it.ItemIcon2,
                it.ExtField1,
                it.ExtField2,
                it.ExtField3,
                it.ExtField4,
                it.ExtField5,
                it.IsSuper,
                it.OpenType,
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
        /// 修改角色菜单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCPowerItem(JCPowerItem parm)
        {
            var response = Update(w => w.ItemId == parm.ItemId, it => new JCPowerItem()
            {
                ParentId = parm.ParentId,
                ItemName = parm.ItemName,
                ItemCode = parm.ItemCode,
                ItemPath = parm.ItemPath,
                ItemType = parm.ItemType,
                InheritType = parm.InheritType,
                ItemValue = parm.ItemValue,
                ProductId = parm.ProductId,
                ItemUrlLike = parm.ItemUrlLike,
                PowerCode = parm.PowerCode,
                OrderId = parm.OrderId,
                ItemIcon1 = parm.ItemIcon1,
                ItemIcon2 = parm.ItemIcon2,
                ExtField1 = parm.ExtField1,
                ExtField2 = parm.ExtField2,
                ExtField3 = parm.ExtField3,
                ExtField4 = parm.ExtField4,
                ExtField5 = parm.ExtField5,
                IsSuper = parm.IsSuper,
                OpenType = parm.OpenType,
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
        /// 清空角色菜单
        /// </summary>
        /// <returns></returns>
        public void TruncateJCPowerItem()
        {
            Truncate();
        }
        #endregion
    }
}