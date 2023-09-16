using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.AskedQuestionViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(4)]
	public class QuestionController : Controller
    {
        private readonly IQusetion _Question;

        public QuestionController(IQusetion question)
        {
            _Question = question;
        }

        //AskerQustions contoroller
        [HttpGet]
		[PermissionChecker(4)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var project = _Question.GetAllAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(36)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var project = _Question.GetDeleteAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(32)]
		public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(32)]
		public IActionResult Create(CreateAskedQuestion model)
        {
            if (ModelState.IsValid)
            {
            var result = _Question.Create(model);
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
		[PermissionChecker(34)]
		public IActionResult Delete(long id)
        {
            var result = _Question.Delete(id);
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
		[PermissionChecker(35)]
		public IActionResult GetRecovery(long id)
        {
            var result = _Question.Recovery(id);
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
		[PermissionChecker(33)]
		public IActionResult Edit(long id)
        {
            var model = _Question.GetDetails(id);
            EditAskedQuestion edit = new EditAskedQuestion();
            edit.Id = model.Id;
            edit.Qusetion = model.Qusetion;
            edit.Answer = model.Answer;
            edit.OrderBy = model.OrderBy;
            return View(edit);
        }

        [HttpPost]
		[PermissionChecker(33)]
		public IActionResult Edit(EditAskedQuestion model)
        {
            if (ModelState.IsValid)
            {
                var result = _Question.Edit(model);
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
