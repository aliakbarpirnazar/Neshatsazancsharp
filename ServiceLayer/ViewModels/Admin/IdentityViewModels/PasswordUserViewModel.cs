using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class PasswordUserViewModel
    {
        public long Id { get; set; }

        [Display(Name = "رمز عبور جدید")]
        public string pass { get; set; }
        public string DisplayName { get; set; }
    }
}
