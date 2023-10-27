using System;
using Infrastructure.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Repository.System
{
    /// <summary>
    /// 通知公告表仓储
    ///
    /// @author fdsoft.codegenerator
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class SysNoticeRepository : BaseRepository<SysNotice>
    {
        #region 业务逻辑代码
        #endregion
    }
}