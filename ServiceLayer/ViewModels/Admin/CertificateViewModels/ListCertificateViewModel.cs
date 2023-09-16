using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.CertificateViewModels
{
    public class ListCertificateViewModel
    {
        [Display(Name = "آیدی")]
        public long Id { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }

        [Display(Name = "عنوان گواهی با افتخار ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

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
