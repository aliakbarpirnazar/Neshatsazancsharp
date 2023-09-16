using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnNewsSiteViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnNewsSiteViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetNewsSiteEn();
            return View(slide);
        }
    }
}
