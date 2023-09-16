using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.ProjectManagement
{
    public class Project :EntityBase
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get;  set; }

        [Display(Name = "عکس")]
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

        [Display(Name = "لینک گوگل آدرس پروژه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LinkLocation { get;  set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public DateTime StartDate { get;  set; } 
        
        [Display(Name = "تاریخ اتمام")]
        public DateTime? EndDate { get;  set; }

        [Display(Name = "مکان احداث")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string AddressLocation { get;  set; }

        [Display(Name = "مساحت مفید")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Usefularea { get;  set; }

        [Display(Name = "مالک")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string OwnerProject { get;  set; }
        
        [Display(Name = "مجری")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PresenterProject { get;  set; }

        [Display(Name = "بودجه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string BudgetProject { get;  set; }

        [Display(Name = "تعداد واحد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public int NumberUnit { get;  set; }

        [Display(Name = "نوع سازه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string TypeStructureProject { get;  set; }

        [Display(Name = "نوع قرار داد")]
        public string? TypeContract { get;  set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        public List<SliderProject> sliderProjects { get;  set; }




    }
}
