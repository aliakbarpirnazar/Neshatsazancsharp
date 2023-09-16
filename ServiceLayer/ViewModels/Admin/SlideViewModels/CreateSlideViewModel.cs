using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SlideViewModels
{
    public class CreateSlideViewModel
    {
        [Display(Name = "عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public IFormFile Picture { get; set; }

        [Display(Name = "ALT عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string PictureAlt { get;  set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string PictureTitle { get;  set; }

        [Display(Name = "تیتر")]
        [MaxLength(255, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Heading { get;  set; }

        [Display(Name = "عنوان")]
        [MaxLength(255, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Title { get;  set; }

        [Display(Name = "متن")]
        [MaxLength(255, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Text { get;  set; }     

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }
    }
}
