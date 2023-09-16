using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Client.Farsi.Menu
{
	public class SettingsMenuViewModel
	{
		[Display(Name = "لوگو")]
		public string LogoStr { get; set; }

		[Display(Name = "متن جایگذین لوگو")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		public string LogoAlt { get; set; }

		[Display(Name = "عنوان لوگو")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		public string LogoTitle { get; set; }
	}
}
