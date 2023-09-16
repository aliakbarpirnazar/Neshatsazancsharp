using DataLayer.Models.IdentityManagement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Security.Claims;
using ServiceLayer.ViewModels.Admin.IdentityViewModels;

namespace Neshatsazan.Controllers
{
	public class IdentityController : Controller
	{
		private readonly IIdentityService _identityService;

		public IdentityController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[HttpGet]
		[Route("Login")]
		public IActionResult LoginByMobile()
		{
			if (User.Identity.IsAuthenticated)
			{
				TempData["warning"] = "کاربر عزیز شما دسترسی به این بخش را ندارید";
				return Redirect("/administration");
			}
			return View();
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult LoginByMobile(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = _identityService.LoginByPhoneNumber(model.PhoneNumber, model.Password);
				if (user == null)
				{
					TempData["error"] = "شماره موبایل یا رمز عبور اشتباه میباشد";
					return View(model);
				}
				else
				{
					if (user.IsDeleted == true)
					{
						TempData["error"] = "حساب شما مسدود شده است لطفا با پشتیبانی تماس بگیرید";

						return Redirect("/login");
					}
					else
					{
						var claims = new List<Claim>()
							{
								new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
								new Claim(ClaimTypes.Name,user.PhoneNumber)
							};
						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var principal = new ClaimsPrincipal(identity);

						var properties = new AuthenticationProperties
						{
							IsPersistent = model.RememberMe,
							AllowRefresh = true
						};
						HttpContext.SignInAsync(principal, properties);


						TempData["success"] = "با موفقیت به حساب کاربری خود وارد شدید";
						return Redirect("/Administration");
					}
				}
			}

			TempData["warning"] = "کاربر عزیز متاسفانه ورود موفقیت آمیز نبود";
			return View(model);
		}

		//LogOut account

		[Route("LogOut")]
		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			TempData["info"] = "از اکانت کاربری خود خارج شدید";
			return Redirect("/");
		}

	}
}
