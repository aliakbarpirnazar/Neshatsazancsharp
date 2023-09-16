using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi.Menu;

namespace NeshatSazan.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public MenuViewComponent(IQueryClients iquery)
        {
           _Iquery = iquery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuViewModel
            {
                siteInfoMenu = _Iquery.GetSiteInfoFarsiMenus(),
                SettingMenu = _Iquery.GetSettingsFarsiMenus(),
                ArticleCategory = _Iquery.GetArticleCategoryFarsi(),
            };

            return View(result);
        }
    }
}
