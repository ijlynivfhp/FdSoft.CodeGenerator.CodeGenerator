using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 仓储
    ///
    /// @author admin
    /// @date 2023-07-11
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class LaborGateRepository : BaseRepository<LaborGate>
    {
        #region 业务逻辑代码
        #endregion
    }
}