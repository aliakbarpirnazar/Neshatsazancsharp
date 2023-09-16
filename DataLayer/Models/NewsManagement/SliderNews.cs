using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.NewsManagement
{
    public class SliderNewsSite:EntityBase
    {
        [Display(Name = "عکس")]
        public string Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        public long? NewsSiteId { get;  set; }
        [ForeignKey("NewsSiteId")]
        public NewsSite? NewsSite { get;  set; }
    }
}
