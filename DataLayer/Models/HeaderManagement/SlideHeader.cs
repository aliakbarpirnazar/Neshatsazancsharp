using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.HeaderManagement
{
    public class SlideHeader : EntityBase
    {
        [Display(Name = "عکس")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        public string Picture { get; set; }

        [Display(Name = "ALT عکس")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "تیتر")]
        [MaxLength(255,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Heading { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(255,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Title { get; set; }

        [Display(Name = "متن")]
        [MaxLength(255,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Text { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

      
        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
