using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnProjectViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnProjectViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetProjectsEn();
            return View(slide);
        }
    }
}
