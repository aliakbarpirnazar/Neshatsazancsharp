using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnSiteinfoViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnSiteinfoViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetSiteInfoEn();
            return View(slide);
        }
    }
}
