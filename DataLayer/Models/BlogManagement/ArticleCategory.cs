using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.BlogManagement
{
    public class ArticleCategory : EntityBase
    {
        [Display(Name = "نام")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string Name { get; private set; }

        [Display(Name = "عکس")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Picture { get; private set; }

        [Display(Name = "متن جایگذین")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string PictureAlt { get; private set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string PictureTitle { get; private set; }

        [Display(Name = "توضیحات")]
        [MaxLength(2000,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string Description { get; private set; }

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public int ShowOrder { get; private set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string Slug { get; private set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string Keywords { get; private set; }

        [Display(Name = "چکیده توضیحات")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نام دسته نباید بدون مقدار باشد")]
        public string MetaDescription { get; private set; }

        [Display(Name = "آدرس محتوا مشابه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? CanonicalAddress { get; private set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string description, int showOrder, string slug, string keywords, string metaDescription,
            string canonicalAddress, string language)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Language = language;
            IsRemoved=false;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description, int showOrder,
            string slug, string keywords, string metaDescription, string canonicalAddress,string lang)
        {
            Name = name;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Language = lang;
        }
    }
}
