using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ProjectViewModels
{
    public class EditProjectViewModel 
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        [Display(Name = "زبان")]
        public string Language { get; set; }

        [Display(Name = "عکس شاخص")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "متن جایگذین عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Keywords { get; set; }

        [Display(Name = "لینک گوگل Maps")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string LinkLocation { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string StartDate { get; set; }

        [Display(Name = "آدرس پروژه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string AddressLocation { get; set; }

        [Display(Name = "مساحت مفید")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Usefularea { get; set; }

        [Display(Name = "تعداد واحد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public int NumberUnit { get; set; }

        [Display(Name = "مالک")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string OwnerProject { get; set; }

        [Display(Name = "مجری")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PresenterProject { get; set; }

        [Display(Name = "بودجه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string BudgetProject { get; set; }

        [Display(Name = "نوع سازه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string TypeStructureProject { get; set; }

        [Display(Name = "نوع قرار داد")]
        public string? TypeContract { get; set; }
        public string? PictureStr { get; set; }
    }
}
