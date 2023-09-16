using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ChartViewModels
{
    public class ChartPictureViewModel
    {
        [Display(Name = "تصویر")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "تصویر")]
        public string? PictureStr { get; set; }

        [Display(Name = "متن جایگذین تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }
    }
}
