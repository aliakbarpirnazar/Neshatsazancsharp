using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi.Menu;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnMenuViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnMenuViewComponent(IQueryClients iquery)
        {
           _Iquery = iquery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuViewModel
            {
                siteInfoMenu = _Iquery.GetSiteInfoEnMenus(),
                SettingMenu = _Iquery.GetSettingsEnMenus(),
                ArticleCategory = _Iquery.GetArticleCategoryEn(),
            };

            return View(result);
        }
    }
}
