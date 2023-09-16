using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class NewsSiteViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public NewsSiteViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetNewsSiteFarsi();
            return View(slide);
        }
    }
}
