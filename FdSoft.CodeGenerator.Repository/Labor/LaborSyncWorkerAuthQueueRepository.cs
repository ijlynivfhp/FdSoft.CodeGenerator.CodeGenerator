using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 同步工人考勤队列仓储
    ///
    /// @author admin
    /// @date 2023-09-06
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class LaborSyncWorkerAuthQueueRepository : BaseRepository<LaborSyncWorkerAuthQueue>
    {
        #region 业务逻辑代码
        #endregion
    }
}