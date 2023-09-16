using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels
{
    public class CreateArticleCategory
    {
        [Display(Name = "نام")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string Name { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public IFormFile Picture { get; set; }

        [Display(Name = "متن جایگذین")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(2000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string Description { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public int ShowOrder { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string Keywords { get; set; }

        [Display(Name = "چکیده توضیحات")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "  نباید بدون مقدار باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "آدرس محتوا مشابه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? CanonicalAddress { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }
    }


}
