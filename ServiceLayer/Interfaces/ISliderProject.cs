using _0_Framework.Application;
using DataLayer.Models.ProjectManagement;
using ServiceLayer.ViewModels.Admin.SliderProjectViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ISliderProject
    {
        List<ListSliderProjectViewModel> GetAllSliderProjectAdmin(long id);
        List<ListSliderProjectViewModel> GetAllDeleteSliderProjectAdmin(long id);
        OperationResult CreatePicSlide(CreateSliderProjectViewModel command);
        SliderProject Get(long id);
        OperationResult EditPicSlide(EditSliderProjectViewModel command);
        EditSliderProjectViewModel GetDetails(long id);
        OperationResult SliderDelete(long id);
        OperationResult SliderRecovery(long id);
    }
}
