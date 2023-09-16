using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnBlogsViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnBlogsViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetBlogEn();
            return View(slide);
        }
    }
}
