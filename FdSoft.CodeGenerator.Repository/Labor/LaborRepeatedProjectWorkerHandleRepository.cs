using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 重复工人处理仓储
    ///
    /// @author admin
    /// @date 2023-06-27
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class LaborRepeatedProjectWorkerHandleRepository : BaseRepository<LaborRepeatedProjectWorkerHandle>
    {
        #region 业务逻辑代码
        #endregion
    }
}