using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public SliderViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetSlideFarsi();
            return View(slide);
        }
    }
}
