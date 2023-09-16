using _0_Framework.Application;
using DataLayer.Models.HeaderManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.SlideViewModels;

namespace ServiceLayer.Services.Interfaces
{
    public interface ISlide
    {
        EditSlideViewModel GetDetails(long id);
        BaseFilterViewModel<SlideViewModel> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<SlideViewModel> GetDeleteAdmin(int pageIndex, string search);
        OperationResult Create(CreateSlideViewModel command);
        OperationResult Edit(EditSlideViewModel command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        SlideHeader Get(long id);

      
    }
}
