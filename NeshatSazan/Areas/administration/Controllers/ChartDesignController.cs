using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(8)]
	public class ChartDesignController : Controller
    {
        private readonly IChartDesign _chartDesign;

        public ChartDesignController(IChartDesign chartDesign)
        {
            _chartDesign = chartDesign;
        }

        [HttpGet]
		[PermissionChecker(8)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var chartDesign = _chartDesign.GetAllAdmin(pageId, search);
            return View(chartDesign);
        }

        [HttpGet]
		[PermissionChecker(68)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var chartDesign = _chartDesign.GetDeleteAdmin(pageId, search);
            return View(chartDesign);
        }

        [HttpGet]
		[PermissionChecker(64)]
		public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(64)]
		public IActionResult Create(CreateChartDesignViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _chartDesign.Create(model);
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
		[PermissionChecker(66)]
		public IActionResult Delete(long id)
        {
            var result = _chartDesign.Remove(id);
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
		[PermissionChecker(67)]
		public IActionResult GetRecovery(long id)
        {
            var result = _chartDesign.Restore(id);
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
		[PermissionChecker(65)]
		public IActionResult Edit(long id)
        {
            var model = _chartDesign.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(65)]
		public IActionResult Edit(EditChartDesignViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _chartDesign.Edit(model);
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
