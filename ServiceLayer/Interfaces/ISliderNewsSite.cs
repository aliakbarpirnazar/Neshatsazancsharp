using _0_Framework.Application;
using DataLayer.Models.NewsManagement;
using ServiceLayer.ViewModels.Admin.SliderNewsSiteViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ISliderNewsSite
    {
        List<ListSliderNewsSiteViewModel> GetAllSliderAdmin(long id);
        List<ListSliderNewsSiteViewModel> GetAllDeleteSliderAdmin(long id);
        OperationResult CreatePicSlide(CreateSliderNewsSiteViewModel command);
        SliderNewsSite Get(long id);
        OperationResult EditPicSlide(EditSliderNewsSiteViewModel command);
        EditSliderNewsSiteViewModel GetDetails(long id);
        OperationResult SliderDelete(long id);
        OperationResult SliderRecovery(long id);
    }
}
