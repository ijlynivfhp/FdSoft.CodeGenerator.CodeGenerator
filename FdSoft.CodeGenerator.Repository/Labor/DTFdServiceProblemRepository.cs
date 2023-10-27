using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 凡东业务问题数据汇总仓储
    ///
    /// @author admin
    /// @date 2023-06-30
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class DTFdServiceProblemRepository : BaseRepository<DTFdServiceProblem>
    {
        #region 业务逻辑代码
        #endregion
    }
}