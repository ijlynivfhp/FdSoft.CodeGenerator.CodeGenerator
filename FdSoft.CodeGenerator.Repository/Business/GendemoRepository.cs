using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 演示仓储
    ///
    /// @author zz
    /// @date 2022-03-31
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class GenDemoRepository : BaseRepository<GenDemo>
    {
        #region 业务逻辑代码
        #endregion
    }
}