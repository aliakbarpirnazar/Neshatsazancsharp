using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.NewsSiteViewModels
{
    public class CreateNewsSiteViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "عکس شاخص")]
        public IFormFile Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Keywords { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string StartDate { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }


    }
}
