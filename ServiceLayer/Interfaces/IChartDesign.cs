using _0_Framework.Application;
using DataLayer.Models.InformationManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IChartDesign
    {
        OperationResult Create(CreateChartDesignViewModel command);
        OperationResult Edit(EditChartDesignViewModel command);
        EditChartDesignViewModel GetDetails(long id);
        BaseFilterViewModel<ChartDesignViewModel> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<ChartDesignViewModel> GetDeleteAdmin(int pageIndex, string search);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        ChartDesign Get(long id);

    }
}
