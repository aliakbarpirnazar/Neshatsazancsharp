using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.CertificateViewModels
{
    public class EditCertificateViewModel
    {
        public long Id { get; set; }
        public string? PictureStr { get; set; }
        [Display(Name = "عنوان گواهی با افتخار ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان خارجی گواهی با افتخار ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string EnTitle { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان عکس ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "عکس")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }
    }
}
