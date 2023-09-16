using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi.Footer;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnFooterViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
		public EnFooterViewComponent(IQueryClients iquery)
        {
           _Iquery = iquery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new FooterViewModel
            {
                siteInfoFooter = _Iquery.GetSiteInfoEnFooter(),
                SettingMenu = _Iquery.GetSettingsEnMenus(),
            };

            return View(result);
        }
    }
}
