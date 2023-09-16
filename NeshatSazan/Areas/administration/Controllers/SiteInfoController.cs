using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.SiteInfoViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(15)]

	public class SiteInfoController : Controller
    {
        private readonly ISiteInfo _siteInfo;

        public SiteInfoController(ISiteInfo siteInfo)
        {
            _siteInfo = siteInfo;
        }

		[PermissionChecker(15)]
		public IActionResult Index()
        {
            var model = _siteInfo.GetSiteInfo();
            return View(model);
        }

		[PermissionChecker(15)]
		public IActionResult IndexEN()
        {
            var model = _siteInfo.GetSiteInfoEN();
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(90)]
		public IActionResult UpdateSiteInfo(SiteInfoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _siteInfo.UpdateSiteInfo(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                if (model.Language == "0")
                {

                    return RedirectToAction(nameof(Index));
                }else
                {
                    return RedirectToAction(nameof(IndexEN));
                }
            }
            TempData["error"] ="لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }
    }
}
