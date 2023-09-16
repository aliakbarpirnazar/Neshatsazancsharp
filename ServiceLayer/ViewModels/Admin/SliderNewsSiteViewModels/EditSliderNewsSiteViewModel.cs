using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SliderNewsSiteViewModels
{
    public class EditSliderNewsSiteViewModel
    {
        [Display(Name = "عکس")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }
        public long NewsSiteId { get; set; }
        public string? PictureStr { get; set; }
        public long Id { get; set; }
    }
}
