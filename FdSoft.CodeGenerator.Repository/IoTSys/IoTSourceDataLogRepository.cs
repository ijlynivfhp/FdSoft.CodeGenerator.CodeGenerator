using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 设备未解析元数据仓储
    ///
    /// @author admin
    /// @date 2023-09-21
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class IoTSourceDataLogRepository : BaseRepository<IoTSourceDataLog>
    {
        #region 业务逻辑代码
        #endregion
    }
}