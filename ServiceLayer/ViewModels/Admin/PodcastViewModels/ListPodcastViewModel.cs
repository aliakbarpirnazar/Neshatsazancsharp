using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.PodcastViewModels
{
    public class ListPodcastViewModel
    {
        [Display(Name = "آیدی")]
        public long Id { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }

        [Display(Name = "عنوان پادکست")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string videoTitle { get; set; }

        [Display(Name = "ویدیو")]
        public string video { get; set; }

        [Display(Name = "متن جایگذین ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string videoAlt { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }
    }
}
