using FdSoft.CodeGenerator.Common.Attribute;
using SqlSugar;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Service.System.IService;

namespace FdSoft.CodeGenerator.Service.System
{
    /// <summary>
    /// 
    /// </summary>
    [AppService(ServiceType = typeof(IArticleService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleService : BaseService<Article>, IArticleService
    {
    }
}
