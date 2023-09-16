using Microsoft.AspNetCore.Mvc;
using ServiceLayer.PublicClass;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels;

namespace NeshatSazan.Areas.Administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(10)]
	public class ArticleCategoriesController : Controller
    {
        private readonly IArticleCategory _articleCategoryApplication;

        public ArticleCategoriesController(IArticleCategory articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

		[PermissionChecker(10)]
		public IActionResult Index(ArticleCategoryIndexViewModel viewModel)
        {
            ArticleCategoryIndexViewModel vm = new ArticleCategoryIndexViewModel();
            vm.articleCategory = _articleCategoryApplication.Search(viewModel);
            return View(vm);
        }

        [HttpGet]
		[PermissionChecker(70)]
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[PermissionChecker(70)]
		public IActionResult Create(CreateArticleCategory command)
        {
            if (ModelState.IsValid)
            {
                var result = _articleCategoryApplication.Create(command);
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
            return View(command);
        }

        [HttpGet]
		[PermissionChecker(71)]
		public IActionResult Edit(long id)
        {
            var productCategory = _articleCategoryApplication.GetDetails(id);
            return View(productCategory);
        }

        [HttpPost]
		[PermissionChecker(71)]
		public IActionResult Edit(EditArticleCategory command)
        {
            if (ModelState.IsValid)
            {
                var result = _articleCategoryApplication.Edit(command);
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
            return View(command);
        }

        [HttpGet]
		[PermissionChecker(72)]
		public IActionResult Delete(long id)
        {
            var result = _articleCategoryApplication.Delete(id);
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
		[PermissionChecker(73)]
		public IActionResult GetRecovery(long id)
        {
            var result = _articleCategoryApplication.Recovery(id);
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



    }
}
