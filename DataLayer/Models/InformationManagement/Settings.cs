using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.InformationManagement
{
    public class Settings : EntityBase
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
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Logo { get; set; }

        [Display(Name = "متن جایگذین لوگو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LogoAlt { get; set; }

        [Display(Name = "عنوان لوگو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LogoTitle { get; set; }

        [Display(Name = "آیکون")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Icon { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }


    }
}
