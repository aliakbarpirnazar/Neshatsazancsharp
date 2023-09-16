﻿using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.InformationManagement
{
    public class ChartDesign : EntityBase
    {
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Picture { get; set; }

        [Display(Name = "متن جایگذین تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(255,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string NameFamily { get; set; }

        [Display(Name = "سمت")]
        [MaxLength(255,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string SideCompany { get; set; }
        
        [Display(Name = "جایگاه")]
        [MaxLength(250,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string  Title { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [MaxLength(250,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string?  MetaDescription { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsRemove { get; set; }



    }
}
