using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.NewsManagement
{
    public class NewsSite :EntityBase
    {
        [Display(Name = "عنوان خبر")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get;  set; }

        [Display(Name = "عکس شاخص")]
        public string Picture { get;  set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get;  set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get;  set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get;  set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Keywords { get;  set; }

        [Display(Name = "تاریخ خبر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public DateTime StartDate { get;  set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        public List<SliderNewsSite> sliderNewsSites { get;  set; }
        public List<VideoNewsSite> videoNewsSites { get;  set; }




    }
}
