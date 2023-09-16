using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SliderNewsSiteViewModels
{
    public class CreateSliderNewsSiteViewModel
    {
        [Display(Name = "عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public IFormFile Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }
        public long NewsSiteId { get; set; }
    }
}
