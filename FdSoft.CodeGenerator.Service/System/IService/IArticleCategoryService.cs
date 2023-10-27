using System.Collections.Generic;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);
        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);
        int AddArticleCategory(ArticleCategory parm);
    }
}
