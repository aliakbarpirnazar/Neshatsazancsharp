using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels.Admin.ArticleViewModels;

namespace NeshatSazan.Areas.Administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(11)]
	public class ArticlesController : Controller
    {
        private readonly IArticle _articleApplication;
        private readonly IArticleCategory _articleCategoryApplication;
        public ArticlesController(IArticle articleApplication, IArticleCategory articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        [HttpGet]
		[PermissionChecker(11)]
		public IActionResult Index(ArticleIndexViewModel viewModel)
        {
            viewModel.articleModels = _articleApplication.Search(viewModel);
            viewModel.ArticleCategories = _articleCategoryApplication.GetArticleCategories();

            return View(viewModel);
        }

        [HttpGet]
		[PermissionChecker(74)]
		public IActionResult Create()
        {
            CreateArticle vm = new CreateArticle();
            vm.ArticleCategories = _articleCategoryApplication.GetArticleCategories();
            return View(vm);

        }

        [HttpPost]
		[PermissionChecker(74)]
		public IActionResult Create(CreateArticle command)
        {

            if (ModelState.IsValid)
            {
                var result = _articleApplication.Create(command);
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
            command.ArticleCategories = _articleCategoryApplication.GetArticleCategories();
            return View(command);
        }

        [HttpGet]
		[PermissionChecker(75)]
		public IActionResult Edit(long id)
        {
            EditArticle vm = new EditArticle();
            vm = _articleApplication.GetDetails(id);
            vm.ArticleCategories = _articleCategoryApplication.GetArticleCategories();
            return View(vm);

        }

        [HttpPost]
		[PermissionChecker(75)]
		public IActionResult Edit(EditArticle command)
        {
            if (ModelState.IsValid)
            {
                var result = _articleApplication.Edit(command);
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
            command.ArticleCategories = _articleCategoryApplication.GetArticleCategories();
            return View(command);
        }

        [HttpGet]
		[PermissionChecker(76)]
		public IActionResult Delete(long id)
        {
            var result = _articleApplication.Delete(id);
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
		[PermissionChecker(77)]
		public IActionResult GetRecovery(long id)
        {
            var result = _articleApplication.Recovery(id);
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
