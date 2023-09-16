using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.CertificateManagement
{
    public class Certificate : EntityBase
    {
        [Display(Name = "عنوان گواهی با افتخار ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان خارجی گواهی با افتخار ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string EnTitle { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "عکس")]
        public string Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }
    }
}
