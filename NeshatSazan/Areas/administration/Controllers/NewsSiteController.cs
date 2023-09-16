using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.NewsSiteViewModels;
using ServiceLayer.ViewModels.Admin.SliderNewsSiteViewModels;
using ServiceLayer.ViewModels.Admin.VideoNewsSiteViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(5)]
	public class NewsSiteController : Controller
    {
        private readonly INewsSite _NewsSite;
        private readonly ISliderNewsSite _SliderNewsSite;
        private readonly IVideoNewsSite _VideoNewsSite;


        public NewsSiteController(INewsSite newsSite, ISliderNewsSite slidernewsSite, IVideoNewsSite videoNewsSite)
        {
            _NewsSite = newsSite;
            _SliderNewsSite = slidernewsSite;
            _VideoNewsSite = videoNewsSite;
        }

        //NewsSite contoroller
        [HttpGet]
		[PermissionChecker(5)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var NewsSite = _NewsSite.GetAllAdmin(pageId, search);
            return View(NewsSite);
        }

        [HttpGet]
		[PermissionChecker(41)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var NewsSite = _NewsSite.GetDeleteAdmin(pageId, search);
            return View(NewsSite);
        }

        [HttpGet]
		[PermissionChecker(37)]
		public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(37)]
		public IActionResult Create(CreateNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _NewsSite.Create(model);
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
		[PermissionChecker(39)]
		public IActionResult Delete(long id)
        {
            var result = _NewsSite.Delete(id);
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
		[PermissionChecker(40)]
		public IActionResult GetRecovery(long id)
        {
            var result = _NewsSite.Recovery(id);
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
		[PermissionChecker(38)]
		public IActionResult Edit(long id)
        {
            var model = _NewsSite.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(38)]
		public IActionResult Edit(EditNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _NewsSite.Edit(model);
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

        //SliderNewsSite Contoroller

        [HttpGet]
		[PermissionChecker(42)]
		public IActionResult IndexSlider(long id)
        {
            var SliderNewsSite = _SliderNewsSite.GetAllSliderAdmin(id);
            var NewsSite = _NewsSite.Get(id);
            ViewBag.TitleNewsSite = NewsSite.Title;
            ViewBag.Id = NewsSite.Id;
            return View(SliderNewsSite);
        }

        [HttpGet]
		[PermissionChecker(47)]
		public IActionResult RecoverySlider(long id)
        {
            var SliderNewsSite = _SliderNewsSite.GetAllDeleteSliderAdmin(id);
            var NewsSite = _NewsSite.Get(id);
            ViewBag.TitleNewsSite = NewsSite.Title;
            ViewBag.Id = NewsSite.Id;
            return View(SliderNewsSite);
        }

        [HttpGet]
		[PermissionChecker(43)]
		public IActionResult SliderCreate(long id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
		[PermissionChecker(43)]
		public IActionResult SliderCreate(CreateSliderNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _SliderNewsSite.CreatePicSlide(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/NewsSite/IndexSlider/" + model.NewsSiteId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(44)]
		public IActionResult SliderEdit(long id)
        {
            var model = _SliderNewsSite.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(44)]
		public IActionResult SliderEdit(EditSliderNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _SliderNewsSite.EditPicSlide(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/NewsSite/IndexSlider/" + model.NewsSiteId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(45)]
		public IActionResult SliderDelete(long id)
        {
            var result = _SliderNewsSite.SliderDelete(id);
            var NewsSite = _SliderNewsSite.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/NewsSite/IndexSlider/" + NewsSite.NewsSiteId);
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
		[PermissionChecker(46)]
		public IActionResult GetSliderRecovery(long id)
        {
            var result = _SliderNewsSite.SliderRecovery(id);
            var NewsSite = _SliderNewsSite.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/NewsSite/IndexSlider/" + NewsSite.NewsSiteId);
            //return RedirectToAction(nameof(Index));
        }


        //VideoNewsSite Controller

        [HttpGet]
		[PermissionChecker(48)]
		public IActionResult IndexVideo(long id)
        {
            var SliderNewsSite = _VideoNewsSite.GetAllAdmin(id);
            var NewsSite = _NewsSite.Get(id);
            ViewBag.TitleNewsSite = NewsSite.Title;
            ViewBag.Id = NewsSite.Id;
            return View(SliderNewsSite);
        }
        [HttpGet]
		[PermissionChecker(53)]
		public IActionResult RecoveryVideo(long id)
        {
            var SliderNewsSite = _VideoNewsSite.GetAllDeleteAdmin(id);
            var NewsSite = _NewsSite.Get(id);
            ViewBag.TitleNewsSite = NewsSite.Title;
            ViewBag.Id = NewsSite.Id;
            return View(SliderNewsSite);
        }

        [HttpGet]
		[PermissionChecker(49)]
		public IActionResult VideoCreate(long id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
		[PermissionChecker(49)]
		public IActionResult VideoCreate(CreateVideoNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _VideoNewsSite.CreateVideo(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/NewsSite/IndexVideo/" + model.NewsSiteId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(50)]
		public IActionResult VideoEdit(long id)
        {
            var model = _VideoNewsSite.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(50)]
		public IActionResult VideoEdit(EditVideoNewsSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _VideoNewsSite.EditVideo(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/NewsSite/IndexVideo/" + model.NewsSiteId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(51)]
		public IActionResult VideoDelete(long id)
        {
            var result = _VideoNewsSite.VideoDelete(id);
            var NewsSite = _VideoNewsSite.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/NewsSite/IndexVideo/" + NewsSite.NewsSiteId);
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
		[PermissionChecker(52)]
		public IActionResult GetVideoRecovery(long id)
        {
            var result = _VideoNewsSite.VideoRecovery(id);
            var NewsSite = _VideoNewsSite.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/NewsSite/IndexVideo/" + NewsSite.NewsSiteId);
            //return RedirectToAction(nameof(Index));
        }




    }
}
