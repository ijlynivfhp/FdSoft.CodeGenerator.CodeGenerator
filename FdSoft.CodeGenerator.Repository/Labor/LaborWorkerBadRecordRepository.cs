using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 工人不良记录仓储
    ///
    /// @author admin
    /// @date 2023-09-11
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class LaborWorkerBadRecordRepository : BaseRepository<LaborWorkerBadRecord>
    {
        #region 业务逻辑代码
        #endregion
    }
}