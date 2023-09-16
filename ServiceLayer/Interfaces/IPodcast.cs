using _0_Framework.Application;
using DataLayer.Models.PodcastManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.PodcastViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Interfaces
{
    public interface IPodcast
    {
        OperationResult Create(CreatePodcastViewModel command);
        OperationResult Edit(EditPodcastViewModel command);
        bool Exists(Expression<Func<Podcast, bool>> experssion);
        BaseFilterViewModel<ListPodcastViewModel> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<ListPodcastViewModel> GetDeleteAdmin(int pageIndex, string search);
        EditPodcastViewModel GetDetails(long id);
        Podcast Get(long id);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);

    }
}
