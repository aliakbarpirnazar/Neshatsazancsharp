using Microsoft.AspNetCore.Http;
using ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ArticleViewModels
{
    public class CreateArticle
    {
        [Display(Name = "عنوان")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public IFormFile Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "تاریخ ارسال")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PublishDate { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Keywords { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "آدرس محتوا مشابه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? CanonicalAddress { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "ترتیب نمایش باید بین 1 تا 100 باشد")]
        public long CategoryId { get; set; }
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
    }
}
