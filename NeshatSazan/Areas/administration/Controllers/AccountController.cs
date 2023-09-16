using DataLayer.Models.IdentityManagement;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.ViewModels.Admin.IdentityViewModels;
using System.Threading;

namespace Neshatsazan.Areas.administration.Controllers
{
	[Area(nameof(administration))]
	[PermissionChecker(12)]
	public class AccountController : Controller
	{
		private readonly IIdentityService _identityService;

		public AccountController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[PermissionChecker(12)]
		//For User
		public IActionResult Index(int pageId)
		{
			var userList = _identityService.GetAllUsersForAdmin(pageId);
			return View(userList);
		}

		[HttpGet]
		[PermissionChecker(79)]
		public IActionResult EditUser(long id)
		{
			var user = _identityService.GetUser(id);
			EditUserViewModel vm = new EditUserViewModel();
			vm.Roles = _identityService.GetSelectList();
			vm.Id = user.UserId;
			vm.PhoneNumber = user.PhoneNumber;
			vm.DisplayName = user.DisplayName;
			vm.RoleId = _identityService.GetRoleid(id);
			return View(vm);
		}

		[HttpPost]
		[PermissionChecker(79)]
		public IActionResult EditUser(EditUserViewModel model)
		{
            model.Roles = _identityService.GetSelectList();
            if (ModelState.IsValid)
			{
				var result = _identityService.EditUser(model);
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
		[PermissionChecker(82)]
		public IActionResult PasswordUser(long id)
		{
			var user = _identityService.GetUser(id);
			PasswordUserViewModel vm = new PasswordUserViewModel();
			vm.Id = user.UserId;
			vm.DisplayName = user.DisplayName;
			return View(vm);
		}

		[HttpPost]
		[PermissionChecker(82)]
		public IActionResult PasswordUser(PasswordUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = _identityService.PasswordUser(model);
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
		[PermissionChecker(78)]
		public IActionResult AddUser()
		{
			CreateUserViewModel vm = new CreateUserViewModel();
			vm.Roles = _identityService.GetSelectList();
            return View(vm);
		}

		[HttpPost]
		[PermissionChecker(78)]
		public IActionResult AddUser(CreateUserViewModel model)
		{
			model.Roles = _identityService.GetSelectList();
			if (ModelState.IsValid)
			{
				var result = _identityService.AddUser(model);
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
		[PermissionChecker(80)]
		public IActionResult DeleteUser(int id)
		{
			_identityService.DeleteUser(id);
			TempData["Success"] = "نقش با موفقیت غیر فعال شد";
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[PermissionChecker(81)]
		public IActionResult RecoveryUser(int id)
		{
			_identityService.RecoveryUser(id);
			TempData["Success"] = "نقش با موفقیت غیر فعال شد";
			return RedirectToAction(nameof(Index));
		}

		//For Role


		[HttpGet]
		[PermissionChecker(13)]
		public IActionResult RolesList(int pageId)
		{
			var roleList = _identityService.GetAllRoleForAdmin(pageId);
			return View(roleList);
		}

		[HttpGet]
		[PermissionChecker(84)]
		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
		[PermissionChecker(84)]
		public IActionResult AddRole(RoleViewModel viewModel)
		{
			if (ModelState.IsValid)
			{

				if (_identityService.IsExistRoleTitle(viewModel.Title))
				{
					TempData["Error"] = "نقش اضافه نشد تکراری است ";
					return RedirectToAction(nameof(RolesList));

				}
				else
				{
					Role role = new Role()
					{
						Title = viewModel.Title,
						IsDeleted = viewModel.IsDeleted,
					};
					_identityService.AddRole(role);
					TempData["Success"] = "نقش با موفقیت اضافه شد";
					return RedirectToAction(nameof(RolesList));
				}
			}
			return View(viewModel);
		}

		[HttpGet]
		[PermissionChecker(85)]
		public IActionResult EditRole(long id)
		{
			Role role = _identityService.GetRole(id);
			RoleViewModel viewModel = new RoleViewModel()
			{
				Title = role.Title,
				IsDeleted = role.IsDeleted
			};
			return View(viewModel);
		}

		[HttpPost]
		[PermissionChecker(85)]

		public IActionResult EditRole(long id, RoleViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (_identityService.IsExistRoleTitle(viewModel.Title))
				{
					TempData["Error"] = "نقش ویرایش نشد ";
					return RedirectToAction(nameof(RolesList));
				}
				else
				{
					_identityService.UpdateRole(id, viewModel);
					TempData["Success"] = "نقش با موفقیت ویرایش شد";
					return RedirectToAction(nameof(RolesList));
				}
			}
			TempData["Error"] = "نقش ویرایش نشد ";
			return View(viewModel);

		}

		[HttpGet]
		[PermissionChecker(86)]

		public IActionResult DeleteRole(long id)
		{
			_identityService.DeleteRole(id);
			TempData["Success"] = "نقش با موفقیت غیر فعال شد";
			return RedirectToAction(nameof(RolesList));
		}

		[HttpGet]
		[PermissionChecker(87)]
		public IActionResult RecoveryRole(long id)
		{
			_identityService.RecoveryRole(id);
			TempData["Success"] = "نقش با موفقیت غیر فعال شد";
			return RedirectToAction(nameof(RolesList));
		}

		[HttpGet]
		[PermissionChecker(88)]
		public IActionResult SetAccessLevelRole(long id)
		{
			
			var model = _identityService.GetAllPermission(id);				
			ViewBag.MyId = id;
            return View(model);
		}

		[HttpPost]
		[PermissionChecker(88)]
		public IActionResult SetAccessLevelRole(long id,long roleId , bool IsActive)
		{
			_identityService.UpdateRolePermissions(id,roleId,IsActive);

            return RedirectToAction("SetAccessLevelRole" , roleId);
        }

	}
}
