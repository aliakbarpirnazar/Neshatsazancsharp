using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.PodcastViewModels
{
    public class CreatePodcastViewModel
    {
        [Display(Name = "عنوان پادکست")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

		[Display(Name = "ویدیو")]
		public IFormFile Video { get; set; }

		[Display(Name = "عکس شاخص")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		public IFormFile Picture { get; set; }

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
