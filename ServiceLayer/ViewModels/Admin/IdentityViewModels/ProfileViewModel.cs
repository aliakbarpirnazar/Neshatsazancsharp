using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string DisplayName { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public string RegisteerTime { get; set; }

        [Display(Name = "تصویر")]
        public string Avatar { get; set; }
    
        [Display(Name = "تصویر")]
        public IFormFile Avatarfile { get; set; }
    }
}
