using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SettingsViewModels
{
    public class SettingsViewModel
    {
        [Display(Name = "نام سایت")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string SiteName { get; set; }

        [Display(Name = "توضیح مختصر")]
        [DataType(DataType.MultilineText)]
        public string SiteDesc { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [DataType(DataType.MultilineText)]
        public string SiteKeys { get; set; }

        [Display(Name = "لوگو")]
        public IFormFile? Logo { get; set; }  
        
        [Display(Name = "لوگو")]
        public string? LogoStr { get; set; }

        [Display(Name = "متن جایگذین لوگو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LogoAlt { get; set; }

        [Display(Name = "عنوان لوگو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LogoTitle { get; set; }

        [Display(Name = "آیکون")]
        public IFormFile? Icon { get; set; }

        [Display(Name = "آیکون")]
        public string? IconStr { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }

    }
}
