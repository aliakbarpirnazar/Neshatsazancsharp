using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.PodcastViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(7)]
	public class PodcastController : Controller
    {
        private readonly IPodcast _Podcast;

        public PodcastController(IPodcast podcast)
        {
            _Podcast = podcast;
        }

        [HttpGet]
		[PermissionChecker(7)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var project = _Podcast.GetAllAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(63)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var project = _Podcast.GetDeleteAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(59)]
		public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(59)]
		public IActionResult Create(CreatePodcastViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _Podcast.Create(model);
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
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(60)]
		public IActionResult Delete(long id)
        {
            var result = _Podcast.Delete(id);
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

        [HttpGet]
		[PermissionChecker(62)]
		public IActionResult GetRecovery(long id)
        {
            var result = _Podcast.Recovery(id);
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

        [HttpGet]
		[PermissionChecker(60)]
		public IActionResult Edit(long id)
        {
            var model = _Podcast.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(60)]
		public IActionResult Edit(EditPodcastViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _Podcast.Edit(model);
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
            return View(model);
        }

    }
}
