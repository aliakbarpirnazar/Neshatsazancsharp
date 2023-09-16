using _0_Framework.Application;
using ServiceLayer.ViewModels.Admin.SiteInfoViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ISiteInfo
    {
        SiteInfoViewModel GetSiteInfoEN();
        SiteInfoViewModel GetSiteInfo();
        OperationResult UpdateSiteInfo(SiteInfoViewModel model);

    }
}
