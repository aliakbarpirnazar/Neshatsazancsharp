using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SliderProjectViewModels
{
    public class CreateSliderProjectViewModel
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
        public long ProjectId { get; set; }

    }
}
