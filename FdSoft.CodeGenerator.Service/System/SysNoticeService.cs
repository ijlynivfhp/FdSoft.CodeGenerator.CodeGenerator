using FdSoft.CodeGenerator.Common.Attribute;
using SqlSugar;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Service.System.IService;

namespace FdSoft.CodeGenerator.Service.System
{
    /// <summary>
    /// 通知公告表Service业务层处理
    ///
    /// @author fdsoft.codegenerator
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceType = typeof(ISysNoticeService), ServiceLifetime = LifeTime.Transient)]
    public class SysNoticeService : BaseService<SysNotice>, ISysNoticeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<SysNotice> GetSysNotices()
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SysNotice>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.And(m => m.Status == "0");
            return GetList(predicate.ToExpression());
        }

        #endregion
    }
}