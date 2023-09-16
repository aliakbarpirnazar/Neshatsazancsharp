using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class ProjectViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public ProjectViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetProjectsFarsi();
            return View(slide);
        }
    }
}
