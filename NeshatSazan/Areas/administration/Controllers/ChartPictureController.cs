using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(9)]
	public class ChartPictureController : Controller
    {
        private readonly IchartPicture _siteInfo;

        public ChartPictureController(IchartPicture siteInfo)
        {
            _siteInfo = siteInfo;
        }
		[PermissionChecker(9)]
		public IActionResult Index()
        {
            var model = _siteInfo.GetChartPicture();
            return View(model);
        }
		[PermissionChecker(9)]
		public IActionResult IndexEn()
        {
            var model = _siteInfo.GetChartPictureEN();
            return View(model);
        }

		[PermissionChecker(69)]
		public IActionResult UpdateChartPicture(ChartPictureViewModel model)
        {
            if (ModelState.IsValid)
            {
            var result = _siteInfo.UpdateChartPicture(model);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
                if (model.Language == "0")
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(IndexEn));
            }
            return View(model);
        }
    }
}
