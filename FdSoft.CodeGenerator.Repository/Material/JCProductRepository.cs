using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 产品表仓储
    ///
    /// @author admin
    /// @date 2022-12-12
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class JCProductRepository : BaseRepository<JCProduct>
    {
        #region 业务逻辑代码
        #endregion
    }
}