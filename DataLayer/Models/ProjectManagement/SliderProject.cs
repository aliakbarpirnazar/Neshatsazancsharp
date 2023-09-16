using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.ProjectManagement
{
    public class SliderProject:EntityBase
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

        public long? ProjectId { get;  set; }
        [ForeignKey("ProjectId")]
        public Project? project { get;  set; }
    }
}
