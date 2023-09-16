using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SlideViewModels
{
    public class SlideViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Picture { get;  set; }

        [Display(Name = "تیتر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(255, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Heading { get;  set; }

        [Display(Name = "عنوان")]
        [MaxLength(255, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Title { get;  set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreationDate { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }
    }
}
