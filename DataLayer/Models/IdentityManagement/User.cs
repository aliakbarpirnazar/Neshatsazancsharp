using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.IdentityManagement
{
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string DisplayName { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisteerTime { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }

        [Display(Name = "تصویر")]
        public string Avatar { get; set; }

        #region rel

        public IEnumerable<UserRole> UserRoles { get; set; }

        #endregion
    }
}
