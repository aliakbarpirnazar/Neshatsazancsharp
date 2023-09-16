using _0_Framework.Application;
using DataLayer.Models.BlogManagement;
using ServiceLayer.ViewModels.Admin.ArticleViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services.Interfaces
{
    public interface IArticle
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        EditArticle GetDetails(long id);
        Article GetWithCategory(long id);       
        bool Exists(Expression<Func<Article, bool>> experssion);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
        Article Get(long id);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);

    }
}
