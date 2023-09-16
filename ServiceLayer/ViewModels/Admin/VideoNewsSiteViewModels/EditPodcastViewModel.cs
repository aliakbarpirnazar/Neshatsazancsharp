using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.VideoNewsSiteViewModels
{
    public class EditVideoNewsSiteViewModel
    {
        public long Id { get; set; }
        public string? videoStr { get; set; }
        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان ویدیو ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string videoTitle { get; set; }

        [Display(Name = "ویدیو")]
        public IFormFile? video { get; set; }

        [Display(Name = "متن جایگذین ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string VideoAlt { get; set; }
        public long NewsSiteId { get; set; }
    }
}
