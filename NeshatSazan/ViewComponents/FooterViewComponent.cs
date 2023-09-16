using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi.Footer;

namespace NeshatSazan.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
		public FooterViewComponent(IQueryClients iquery)
        {
           _Iquery = iquery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new FooterViewModel
            {
                siteInfoFooter = _Iquery.GetSiteInfoFarsiFooter(),
                SettingMenu = _Iquery.GetSettingsFarsiMenus(),
            };

            return View(result);
        }
    }
}
