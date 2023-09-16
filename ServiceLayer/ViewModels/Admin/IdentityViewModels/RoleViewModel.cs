using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class RoleViewModel
    {
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsDeleted { get; set; }
    }
}
