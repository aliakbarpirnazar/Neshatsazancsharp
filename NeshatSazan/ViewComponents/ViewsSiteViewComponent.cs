using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
	public class ViewsSiteViewComponent : ViewComponent
    {
		private readonly IProject _project;
		private readonly IVisit _visit;
		public ViewsSiteViewComponent(IProject project, IVisit visit)
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
