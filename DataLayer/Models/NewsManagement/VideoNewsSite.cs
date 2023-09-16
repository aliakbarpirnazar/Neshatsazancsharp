using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.NewsManagement
{
    public class VideoNewsSite : EntityBase
    {
        [Display(Name = "عنوان ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string VideoTitle { get; set; }

        [Display(Name = "ویدیو")]
        public string Video { get; set; }

        [Display(Name = "متن جایگذین ویدیو")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string VideoAlt { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        public long? NewsSiteId { get; set; }
        [ForeignKey("NewsSiteId")]
        public NewsSite? NewsSite { get; set; }
    }
}
