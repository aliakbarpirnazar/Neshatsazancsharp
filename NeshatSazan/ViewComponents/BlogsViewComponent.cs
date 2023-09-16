using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class BlogsViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public BlogsViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetBlogFarsi();
            return View(slide);
        }
    }
}
