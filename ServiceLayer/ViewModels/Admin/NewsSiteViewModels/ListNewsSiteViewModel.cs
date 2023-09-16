using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.NewsSiteViewModels
{
    public class ListNewsSiteViewModel
    {
        [Display(Name = "آیدی")]
        public long Id { get; set; }

        [Display(Name = "عنوان خبر")]
        public string Title { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }

        [Display(Name = "تاریخ خبر")]
        public string StartDate { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }
    }
}
