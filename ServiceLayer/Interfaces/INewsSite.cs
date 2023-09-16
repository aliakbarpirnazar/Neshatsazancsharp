using _0_Framework.Application;
using DataLayer.Models.NewsManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.NewsSiteViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Interfaces
{
    public interface INewsSite
    {
        OperationResult Create(CreateNewsSiteViewModel command);
        OperationResult Edit(EditNewsSiteViewModel command);
        bool Exists(Expression<Func<NewsSite, bool>> experssion);
        BaseFilterViewModel<ListNewsSiteViewModel> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<ListNewsSiteViewModel> GetDeleteAdmin(int pageIndex, string search);
        EditNewsSiteViewModel GetDetails(long id);
        NewsSite Get(long id);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);

    }
}
