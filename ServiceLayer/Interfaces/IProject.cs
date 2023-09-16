using ServiceLayer.ViewModels.Admin.ProjectViewModels;
using ServiceLayer.ViewModels;
using _0_Framework.Application;
using DataLayer.Models.ProjectManagement;

namespace ServiceLayer.Interfaces
{
    public interface IProject
    {
        BaseFilterViewModel<ListProjectViewModel> GetAllProjectAdmin(int pageIndex, string search);
        BaseFilterViewModel<ListProjectViewModel> GetDeleteProjectAdmin(int pageIndex, string search);
        OperationResult Create(CreateProjectViewModel command);
        OperationResult Edit(EditProjectViewModel command);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);
        EditProjectViewModel GetDetails(long id);
        Project Get(long id);
        int GetCount();
        long GetSum();
    }
}
