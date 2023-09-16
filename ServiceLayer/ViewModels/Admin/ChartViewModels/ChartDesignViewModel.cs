using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ChartViewModels
{
    public class ChartDesignViewModel
    {
        public long Id { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string NameFamily { get; set; }

        [Display(Name = "سمت")]
        public string SideCompany { get; set; }

        [Display(Name = "جایگاه")]
        public string Title { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemove { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

    }
    
}
