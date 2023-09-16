using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.VideoNewsSiteViewModels
{
    public class CreateVideoNewsSiteViewModel
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان ویدیو ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string videoTitle { get; set; }

        [Display(Name = "ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public IFormFile video { get; set; }

        [Display(Name = "متن جایگذین ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string videoAlt { get; set; }

        public long NewsSiteId { get; set; }
    }
}
