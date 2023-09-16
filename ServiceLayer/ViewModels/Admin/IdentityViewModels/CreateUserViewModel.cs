using DataLayer.Models.IdentityManagement;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
	public class CreateUserViewModel
    {
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string DisplayName { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        public long RoleId { get; set; }
        public List<Role>? Roles { get; set; }
	}

}
