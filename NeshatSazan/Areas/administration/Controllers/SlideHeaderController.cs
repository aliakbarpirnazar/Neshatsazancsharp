using Microsoft.AspNetCore.Mvc;
using ServiceLayer.PublicClass;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels.Admin.SlideViewModels;

namespace NeshatSazan.Areas.Administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(2)]
	public class SlideHeaderController : Controller
    {
        private readonly ISlide _Slides;

        public SlideHeaderController(ISlide slides)
        {
            _Slides = slides;
        }

        [HttpGet]
		[PermissionChecker(2)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var slide = _Slides.GetAllAdmin(pageId, search);
            return View(slide);
        }

        [HttpGet]
		[PermissionChecker(20)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var slide = _Slides.GetDeleteAdmin(pageId, search);
            return View(slide);
        }

		[PermissionChecker(18)]
		public IActionResult Remove(long id)
        {
            _Slides.Remove(id);
            return RedirectToAction(nameof(Index));
        }

		[PermissionChecker(19)]
		public IActionResult Restore(long id)
        {
            _Slides.Restore(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
		[PermissionChecker(16)]
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[PermissionChecker(16)]
		public IActionResult Create(CreateSlideViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _Slides.Create(viewModel);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(viewModel);
        }

        [HttpGet]
		[PermissionChecker(17)]
		public IActionResult Edit(long id)
        {
            var slide = _Slides.GetDetails(id);
            return View(slide);
        }

        [HttpPost]
		[PermissionChecker(17)]
		public IActionResult Edit(EditSlideViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _Slides.Edit(viewModel);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(viewModel);
        }
    }
}
