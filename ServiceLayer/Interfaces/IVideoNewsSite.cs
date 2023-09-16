using _0_Framework.Application;
using DataLayer.Models.NewsManagement;
using ServiceLayer.ViewModels.Admin.VideoNewsSiteViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IVideoNewsSite
    {
        List<ListVideoNewsSiteViewModel> GetAllAdmin(long id);
        List<ListVideoNewsSiteViewModel> GetAllDeleteAdmin(long id);
        OperationResult CreateVideo(CreateVideoNewsSiteViewModel command);
        VideoNewsSite Get(long id);
        OperationResult EditVideo(EditVideoNewsSiteViewModel command);
        EditVideoNewsSiteViewModel GetDetails(long id);
        OperationResult VideoDelete(long id);
        OperationResult VideoRecovery(long id);
    }
}
