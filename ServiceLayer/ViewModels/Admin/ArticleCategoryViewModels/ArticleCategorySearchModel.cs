using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels
{
    public class ArticleCategorySearchModel
    {
        [Display(Name = "نام")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string Name { get; set; }
    }
}
