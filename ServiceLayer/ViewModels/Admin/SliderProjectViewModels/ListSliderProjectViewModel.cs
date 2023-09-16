using DataLayer.Models.ProjectManagement;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.SliderProjectViewModels
{
    public class ListSliderProjectViewModel
    {
        public long Id { get; set; }
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
        public IEnumerable<Project> projects { get; set; }
    }
}
