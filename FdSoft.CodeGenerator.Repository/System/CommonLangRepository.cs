using System;
using Infrastructure.Attribute;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Repository
{
    /// <summary>
    /// 多语言配置仓储
    ///
    /// @author fdsoft.codegenerator
    /// @date 2022-05-06
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class CommonLangRepository : BaseRepository<CommonLang>
    {
        #region 业务逻辑代码
        #endregion
    }
}