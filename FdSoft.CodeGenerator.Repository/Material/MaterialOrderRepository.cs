using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Model.Models.Material;
using FdSoft.CodeGenerator.Model.Dto.Material;
using System.Linq;
using SqlSugar;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Enums;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 物资出料/收料表仓储
    ///
    /// @author admin
    /// @date 2022-12-05
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class MaterialOrderRepository : BaseRepository<MaterialOrder>
    {
        #region 首页数据
        /// <summary>
        /// 收料
        /// </summary>
        /// <returns></returns>
        public GetReceiveDataDto GetReceiveData(GetReceiveDataPo getReceiveDataPo)
        {
            return Context.Queryable<MaterialOrder>().Where(o => getReceiveDataPo.ProIds.Contains(o.ProId) && o.DeliveryType == 0 && o.OrderType == 1 && o.DeleteStatus == 0)
                .WhereIF(getReceiveDataPo.StartDate.HasValue, o => o.AddDate >= getReceiveDataPo.StartDate.Value)
                .WhereIF(getReceiveDataPo.EndDate.HasValue, o => o.AddDate.Value < getReceiveDataPo.EndDate.Value.AddDays(1)).Select(o => new GetReceiveDataDto()
                {
                    CarCount = SqlFunc.AggregateCount(o),
                    RealWeight = SqlFunc.AggregateSum(o.OrderGoodsWeight),
                    PlanWeight = SqlFunc.AggregateSum(o.OrderPlanOnWeight),
                    RealCount = SqlFunc.AggregateSum(o.OrderPcs),
                    PlanCount = SqlFunc.AggregateSum(o.OrderPlanOnPcs)
                }).Single();
        }

        /// <summary>
        /// 发料
        /// </summary>
        /// <returns></returns>
        public GetSendDataDto GetSendData(GetSendDataPo getSendDataPo)
        {
            return Context.Queryable<MaterialOrder>().Where(o => getSendDataPo.ProIds.Contains(o.ProId) && o.DeliveryType == 1 && o.OrderType == 1 && o.DeleteStatus == 0)
                .WhereIF(getSendDataPo.StartDate.HasValue, o => o.AddDate >= getSendDataPo.StartDate.Value)
                .WhereIF(getSendDataPo.EndDate.HasValue, o => o.AddDate.Value < getSendDataPo.EndDate.Value.AddDays(1)).Select(o => new GetSendDataDto()
                {
                    CarCount = SqlFunc.AggregateCount(o),
                    RealWeight = SqlFunc.AggregateSum(o.OrderGoodsWeight),
                    PlanWeight = SqlFunc.AggregateSum(o.OrderPlanOnWeight),
                    RealCount = SqlFunc.AggregateSum(o.OrderPcs),
                    PlanCount = SqlFunc.AggregateSum(o.OrderPlanOnPcs)
                }).Single();
        }

        /// <summary>
        /// 预警
        /// </summary>
        /// <returns></returns>
        public GetAlarmDataDto GetAlarmData(GetAlarmDataPo getAlarmDataPo)
        {
            return Context.Queryable<MaterialOrder>().Where(o => getAlarmDataPo.ProIds.Contains(o.ProId) && o.EarlyWarnStatus == 1 && o.OrderType == 1 && o.DeleteStatus == 0)
                .WhereIF(getAlarmDataPo.StartDate.HasValue, o => o.AddDate >= getAlarmDataPo.StartDate.Value)
                .WhereIF(getAlarmDataPo.EndDate.HasValue, o => o.AddDate.Value < getAlarmDataPo.EndDate.Value.AddDays(1)).Select(o => new GetAlarmDataDto()
                {
                    CarCount = SqlFunc.AggregateCount(o),
                    RealWeight = SqlFunc.AggregateSum(o.EarlyWarning ? 1 : 0),
                    PlanWeight = SqlFunc.AggregateSum(o.EarlyWarning ? 0 : 1),
                    RealCount = SqlFunc.AggregateSum(o.EarlyWarning ? 1 : 0),
                    PlanCount = SqlFunc.AggregateSum(o.EarlyWarning ? 0 : 1)
                }).Single();
        }

        /// <summary>
        /// 累计收料情况分析
        /// </summary>
        /// <returns></returns>
        public List<GetTotalReceiveAnalyseDto> GetTotalReceiveAnalyseData(GetTotalReceiveAnalysePo getTotalReceiveAnalysePo)
        {
            var dbList = Context.Queryable<MaterialOrder, MaterialOrderGoods, MaterialGoods, MaterialGoodsType>((mo, mog, mg, mgt) => new JoinQueryInfos(
                JoinType.Inner, mo.OrderId == mog.OrderId && mo.DeleteStatus == 0 && mog.DeleteStatus == 0,
                JoinType.Inner, mog.GoodsId == mg.GoodsId,
                JoinType.Inner, mg.MaterialTypeId == mgt.MaterialTypeId
                ))
                .Where(mo => getTotalReceiveAnalysePo.ProIds.Contains(mo.ProId))
                .GroupBy((mo, mog, mg, mgt) => new { mgt.MaterialTypeId, mgt.TypeName })
                .Select((mo, mog, mg, mgt) => new GetTotalReceiveAnalyseDto()
                {
                    MaterialTypeId = mgt.MaterialTypeId,
                    TypeName = mgt.TypeName ?? string.Empty,
                    RealWeight = SqlFunc.AggregateSum(mog.GoodsWeight),
                    PlanWeight = SqlFunc.AggregateSum(mog.GoodsPlanOnWeight),
                    RealCount = SqlFunc.AggregateSum(mog.GoodsPcs),
                    PlanCount = SqlFunc.AggregateSum(mog.GoodsPlanOnPcs),
                    OffsetWeight = SqlFunc.AggregateSum(mog.OffsetWeight),
                    OffsetCount = SqlFunc.AggregateSum(mog.OffsetCount),
                }).ToList();
            dbList.Sort((a, b) => -a.RealWeight.CompareTo(b.RealWeight));
            return dbList;
        }

        /// <summary>
        /// 近一年供货超负差分析
        /// </summary>
        /// <returns></returns>
        public List<GetYearOverNegativeDifferDto> GetYearOverNegativeDifferData(GetYearOverNegativeDifferPo getYearOverNegativeDifferPo)
        {
            return Context.Queryable<MaterialOrder, MaterialOrderGoods>((mo, mog) => new JoinQueryInfos(JoinType.Inner, mo.OrderId == mog.OrderId && mo.DeleteStatus == 0 && mog.DeleteStatus == 0))
                .Where((mo, mog) => getYearOverNegativeDifferPo.ProIds.Contains(mo.ProId))
                .WhereIF(getYearOverNegativeDifferPo.StartDate.HasValue, (mo, mog) => mog.AddDate.Value >= getYearOverNegativeDifferPo.StartDate.Value)
                .WhereIF(getYearOverNegativeDifferPo.EndDate.HasValue, (mo, mog) => mog.AddDate.Value < getYearOverNegativeDifferPo.EndDate.Value.AddDays(1))
                .Select((mo, mog) => new GetYearOverNegativeDifferDto()
                {
                    AddTime = mog.AddDate.Value,
                    CarCount = mog.OffsetResult == 3 ? 1 : 0,
                    TotalCount = 1,
                }).ToList();
        }

        /// <summary>
        /// 现场材料收货监控
        /// </summary>
        /// <returns></returns>
        public List<GetReceiveMonitorDto> GetReceiveMonitorData(GetReceiveMonitorPo getReceiveMonitorPo)
        {
            return Context.Queryable<MaterialOrder, MaterialOrderGoods, MaterialGoodsUnits, JCProject, MaterialGoods>((mo, mog, mgu, jp, mg) =>
                new JoinQueryInfos(
                    JoinType.Inner, mo.OrderId == mog.OrderId && mo.DeleteStatus == 0 && mog.DeleteStatus == 0,
                    JoinType.Left, mog.UnitId == mgu.UnitId,
                    JoinType.Left, mo.ProId == jp.ProId,
                    JoinType.Left, mog.GoodsId == mg.GoodsId)
            )
            .Where(mo => getReceiveMonitorPo.ProIds.Contains(mo.ProId))
            .OrderByDescending((mo) => mo.AddTime)
            .Select((mo, mog, mgu, jp, mg) => new GetReceiveMonitorDto()
            {
                TotalWeight = mog.GoodsWeight,
                UnitName = mgu.UnitName ?? string.Empty,
                OrderStatus = mo.OrderType == 0 ? "收货中" : mo.OrderType == 1 ? "完成收货" : "已取消",
                ProjectName = jp.ProName ?? string.Empty,
                AddTime = mog.AddDate.Value,
                OffsetResult = mog.OffsetResult == 1 ? OffsetResult.超正差.ToString() : mog.OffsetResult == 3 ? OffsetResult.超负差.ToString() : mog.OffsetResult == 2 ? OffsetResult.正常.ToString() : "未设置偏差",
                MtName = mg.GoodsName ?? string.Empty
            }).Take(50).ToList();
        }


        /// <summary>
        /// 累计收料偏差分析
        /// </summary>
        /// <returns></returns>
        public GetTotalReceiveDifferDto GetTotalReceiveDifferData(GetTotalReceiveDifferPo getTotalReceiveDifferPo)
        {
            return Context.Queryable<MaterialOrder, MaterialOrderGoods>((mo, mog) =>
                new JoinQueryInfos(
                    JoinType.Inner, mo.OrderId == mog.OrderId && mo.DeleteStatus == 0 && mog.DeleteStatus == 0
            ))
            .Where((mo, mog) => getTotalReceiveDifferPo.ProIds.Contains(mo.ProId))
            .Select((mo, mog) => new GetTotalReceiveDifferDto()
            {
                NormalCount = SqlFunc.AggregateSum(mog.OffsetResult == 2 ? 1 : 0),
                SuperPositiveCount = SqlFunc.AggregateSum(mog.OffsetResult == 1 ? 1 : 0),
                SuperNegativeDifferCount = SqlFunc.AggregateSum(mog.OffsetResult == 3 ? 1 : 0)
            }).Single();
        }
        #endregion

        #region 业务逻辑代码
        #endregion
    }
}