using _0_Framework.Application;
using DataLayer.Models.AskedQuestionsManagement;
using DataLayer.Models.BlogManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services.Interfaces
{
    public interface IArticleCategory
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);

        string GetSlugBy(long id);
        bool Exists(Expression<Func<ArticleCategory, bool>> experssion);
        ArticleCategory Get(long id);
        List<ArticleCategoryViewModel> GetArticleCategories();
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        public OperationResult Delete(long id);
        public OperationResult Recovery(long id);
        



    }
}
