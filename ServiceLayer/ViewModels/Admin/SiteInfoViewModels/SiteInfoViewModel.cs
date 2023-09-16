using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SiteInfoViewModels
{
    public class SiteInfoViewModel
    {
        [Display(Name = "شماره تماس")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string TelNumber { get; set; }

        [Display(Name = "ساعت کاری")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string TimeRun { get; set; }

        [Display(Name = "آدرس شرکت")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Address { get; set; }

        [Display(Name = "لینک گوگل آدرس شرکت")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LinkLocation { get; set; }

        [Display(Name = "لینک اینستاگرام  ")]
        public string? Linkinstagram { get; set; }

        [Display(Name = "لینک تلگرام  ")]
        public string? LinkTelegram { get; set; }

        [Display(Name = "لینک واتس آپ")]
        public string? LinkWhatsApp { get; set; }

        [Display(Name = "تصویر راهنمای شرکت")]
        public string? PictureStr { get; set; }

        [Display(Name = "تصویر راهنمای شرکت")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "متن جایگذین تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "سوال کوتاه")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Qusetion { get; set; }

        [Display(Name = "توضیح مختصر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Description { get; set; }

        [Display(Name = "ماموریت شرکت")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MissionCompany { get; set; }

        [Display(Name = "چشم انداز شرکت")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string VisionCompany { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }
    }
}
