using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnSliderViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnSliderViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetSlideEn();
            return View(slide);
        }
    }
}
