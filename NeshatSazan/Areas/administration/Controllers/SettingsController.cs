using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.SettingsViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(14)]

	public class SettingsController : Controller
    {
        private readonly ISettings _settings;

        public SettingsController(ISettings settings)
        {
            _settings = settings;
        }


		[PermissionChecker(14)]
		public IActionResult Index()
        {
            var model = _settings.GetSettings();
            return View(model);
        }

		[PermissionChecker(14)]
		public IActionResult IndexEN()
        {
            var model = _settings.GetSettingsEN();
            return View(model);
        }

		[PermissionChecker(89)]
		public IActionResult UpdateSettings(SettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
            var result = _settings.UpdateSettings(model);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            if(model.Language == "0")
            return RedirectToAction(nameof(Index));
            else
            return RedirectToAction(nameof(IndexEN));
            }
            return View(model);
        }
    }
}
