using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.PodcastManagement
{
    public class Podcast : EntityBase
    {
        [Display(Name = "عنوان پادکست")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "ویدیو")]
        public string Video { get; set; }

		[Display(Name = "عکس شاخص")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		public string Picture { get; set; }

		[Display(Name = "متن جایگذین تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }
    }
}
