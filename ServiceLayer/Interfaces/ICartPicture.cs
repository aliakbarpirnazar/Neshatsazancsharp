using _0_Framework.Application;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IchartPicture
    {
        ChartPictureViewModel GetChartPictureEN();
        ChartPictureViewModel GetChartPicture();
        OperationResult UpdateChartPicture(ChartPictureViewModel model);
    }
}
