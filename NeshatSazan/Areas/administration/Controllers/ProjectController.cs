using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.ProjectViewModels;
using ServiceLayer.ViewModels.Admin.SliderProjectViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(3)]
	public class ProjectController : Controller
    {
        private readonly IProject _project;
        private readonly ISliderProject _Sliderproject;

        public ProjectController(IProject project, ISliderProject sliderproject)
        {
            _project = project;
            _Sliderproject = sliderproject;
        }

        //Project contoroller
        [HttpGet]
		[PermissionChecker(3)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var project = _project.GetAllProjectAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(25)]
        public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var project = _project.GetDeleteProjectAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(21)]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(21)]
        public IActionResult Create(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _project.Create(model);

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
		[PermissionChecker(23)]
		public IActionResult Delete(long id)
        {
            var result = _project.Delete(id);
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
		[PermissionChecker(24)]
		public IActionResult GetRecovery(long id)
        {
            var result = _project.Recovery(id);
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
		[PermissionChecker(22)]
		public IActionResult Edit(long id)
        {
            var model = _project.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(22)]
		public IActionResult Edit(EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _project.Edit(model);
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

        //SliderProject Contoroller

        [HttpGet]
		[PermissionChecker(31)]
		public IActionResult IndexSlider(long id)
        {
            var Sliderproject = _Sliderproject.GetAllSliderProjectAdmin(id);
            var project = _project.Get(id);
            ViewBag.TitleProject = project.Title;
            ViewBag.Id = project.Id;
            return View(Sliderproject);
        }

        [HttpGet]
		[PermissionChecker(30)]
		public IActionResult RecoverySlider(long id)
        {
            var Sliderproject = _Sliderproject.GetAllDeleteSliderProjectAdmin(id);
            var project = _project.Get(id);
            ViewBag.TitleProject = project.Title;
            ViewBag.Id = project.Id;
            return View(Sliderproject);
        }

        [HttpGet]
		[PermissionChecker(26)]
		public IActionResult SliderCreate(long id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
		[PermissionChecker(26)]
		public IActionResult SliderCreate(CreateSliderProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _Sliderproject.CreatePicSlide(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/Project/IndexSlider/" + model.ProjectId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(27)]
		public IActionResult SliderEdit(long id)
        {
            var model = _Sliderproject.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(27)]
		public IActionResult SliderEdit(EditSliderProjectViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _Sliderproject.EditPicSlide(model);
                if (result.IsSuccedded == false)
                {
                    TempData["error"] = result.Message;
                }
                else
                {
                    TempData["success"] = result.Message;
                }
                return Redirect("/administration/Project/IndexSlider/" + model.ProjectId);
            }
            TempData["warning"] = "لطفا فیلد های اجباری را پر کنید";
            return View(model);
        }

        [HttpGet]
		[PermissionChecker(28)]
		public IActionResult SliderDelete(long id)
        {
            var result = _Sliderproject.SliderDelete(id);
            var project = _Sliderproject.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/Project/IndexSlider/" + project.ProjectId);
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
		[PermissionChecker(29)]
		public IActionResult GetSliderRecovery(long id)
        {
            var result = _Sliderproject.SliderRecovery(id);
            var project = _Sliderproject.Get(id);
            if (result.IsSuccedded == false)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["success"] = result.Message;
            }
            return Redirect("/administration/Project/IndexSlider/" + project.ProjectId);
            //return RedirectToAction(nameof(Index));
        }


    }
}
