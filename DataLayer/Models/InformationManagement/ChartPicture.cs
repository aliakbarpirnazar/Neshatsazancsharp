using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.InformationManagement
{
    public class ChartPicture : EntityBase
    {
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Picture { get; set; }

        [Display(Name = "متن جایگذین تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

    }
}
