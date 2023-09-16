using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnViewsSiteViewComponent : ViewComponent
    {
		private readonly IProject _project;
		private readonly IVisit _visit;
		public EnViewsSiteViewComponent(IProject project, IVisit visit)
		{
			_project = project;
			_visit = visit;
		}
		public IViewComponentResult Invoke()
        {
			ViewBag.Counter = _project.GetCount();
			ViewBag.Visit = _visit.GetCountComplte();
			ViewBag.Sum = _project.GetSum();
			ViewBag.Contect = ViewBag.sum * 5;

			return View();
        }
    }
}
