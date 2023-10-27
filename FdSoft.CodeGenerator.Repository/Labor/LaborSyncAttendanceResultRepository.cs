using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 工人考勤同步结果表仓储
    ///
    /// @author admin
    /// @date 2023-08-11
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class LaborSyncAttendanceResultRepository : BaseRepository<LaborSyncAttendanceResult>
    {
        #region 业务逻辑代码
        #endregion
    }
}