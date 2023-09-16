using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class SiteinfoViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public SiteinfoViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetSiteInfoFarsi();
            return View(slide);
        }
    }
}
