using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.CertificateViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
	[PermissionChecker(6)]
	public class CertificateController : Controller
    {
        private readonly ICertificate _certificate;

        public CertificateController(ICertificate certificate)
        {
            _certificate = certificate;
        }

        //Certificatecontoroller
        [HttpGet]
		[PermissionChecker(6)]
		public IActionResult Index(int pageId = 1, string search = "")
        {
            var project = _certificate.GetAllAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(58)]
		public IActionResult Recovery(int pageId = 1, string search = "")
        {
            var project = _certificate.GetDeleteAdmin(pageId, search);
            return View(project);
        }

        [HttpGet]
		[PermissionChecker(54)]
		public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		[PermissionChecker(54)]
		public IActionResult Create(CreateCertificateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _certificate.Create(model);
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
		[PermissionChecker(56)]
		public IActionResult Delete(long id)
        {
            var result = _certificate.Delete(id);
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
		[PermissionChecker(57)]
		public IActionResult GetRecovery(long id)
        {
            var result = _certificate.Recovery(id);
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
		[PermissionChecker(55)]
		public IActionResult Edit(long id)
        {
            var model = _certificate.GetDetails(id);
            return View(model);
        }

        [HttpPost]
		[PermissionChecker(55)]
		public IActionResult Edit(EditCertificateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _certificate.Edit(model);
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
