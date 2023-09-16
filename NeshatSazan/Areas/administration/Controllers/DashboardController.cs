using _0_Framework.Application;
using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.IdentityViewModels;

namespace NeshatSazan.Areas.administration.Controllers
{
    [Area(nameof(administration))]
    [PermissionChecker(1)]
    public class DashboardController : Controller
    {
        private readonly IProject _project;
        private readonly IVisit _visit;
        private readonly IIdentityService _identity;
        public DashboardController(IProject project, IVisit visit, IIdentityService identity)
        {
            _project = project;
            _visit = visit;
            _identity = identity;
        }

        [PermissionChecker(1)]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Counter = _project.GetCount();
            ViewBag.Visit = _visit.GetCountComplte();
            ViewBag.Sum = _project.GetSum();
            ViewBag.Contect = ViewBag.sum * 5;
            return View();
        }

        [PermissionChecker(1)]
        [HttpGet]
        public IActionResult Profile(string userName)
        {
            var use = _identity.GetUserProfile(userName);
            ProfileViewModel p = new ProfileViewModel()
            {
                Id = use.UserId,
                Avatar = use.Avatar,
                DisplayName = use.DisplayName,
                PhoneNumber = use.PhoneNumber,
                RegisteerTime = use.RegisteerTime.ToFarsi()
            };
            return View(p);
        }

        [PermissionChecker(1)]
        [HttpPost]
        public IActionResult UpdateProfile(ProfileViewModel model)
        {
            string s = _identity.updateUser(model);
            TempData["success"] = "تغییرات انجام شد.";
            return Redirect("Profile?userName=" + s);
        }

        [PermissionChecker(1)]
        [HttpPost]
        public IActionResult UpdatePasswordProfile(ProfileViewModel model)
        {
            string s = _identity.updateUserPass(model);
            TempData["success"] = "تغییر رمز عبور انجام شد.";
            return Redirect("Profile?userName=" + s);
        }

        [PermissionChecker(1)]
        [HttpPost]
        public IActionResult UpdateAvatarProfile(ProfileViewModel model)
        {
            string s = _identity.updateUserPic(model);
            TempData["success"] = "تغییر تصویر انجام شد.";
            return Redirect("Profile?userName=" + s);
        }


    }
}
