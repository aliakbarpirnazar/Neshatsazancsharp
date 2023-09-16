using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [StringLength(11, ErrorMessage = "مقدار {0} نباید کمتر از {2} و بیشتر از {1} کاراکتر باشد.", MinimumLength = 11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [StringLength(20, ErrorMessage = "مقدار {0} نباید کمتر از {2} و بیشتر از {1} کاراکتر باشد.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

    }

}
