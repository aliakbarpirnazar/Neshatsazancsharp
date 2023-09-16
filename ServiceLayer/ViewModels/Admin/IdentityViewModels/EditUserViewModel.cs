using DataLayer.Models.IdentityManagement;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class EditUserViewModel
    {
        public long Id { get; set; }
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string DisplayName { get; set; }

        public long RoleId { get; set; }
        public List<Role>? Roles { get; set; }
    }
}
