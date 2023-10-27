using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 主动发送数据日志表仓储
    ///
    /// @author admin
    /// @date 2023-05-09
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class DTActivelySendlogsRepository : BaseRepository<DTActivelySendlogs>
    {
        #region 业务逻辑代码
        #endregion
    }
}