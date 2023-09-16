using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ProjectViewModels
{
    public class ListProjectViewModel
    {
        [Display(Name = "آیدی")]
        public long Id { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }

        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }
    }
}
