using System;
using Infrastructure.Attribute;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 参数配置仓储接口的实现
    ///
    /// @author zhaorui
    /// @date 2021-09-29
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class SysConfigRepository : BaseRepository<SysConfig>
    {
        #region 业务逻辑代码
        #endregion
    }
}