using System;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 用户角色关联表仓储
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class JCUserRoleRepository : BaseRepository<JCUserRole>
    {
        #region 业务逻辑代码
        #endregion
    }
}