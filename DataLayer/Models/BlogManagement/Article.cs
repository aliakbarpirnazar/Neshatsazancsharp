using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.BlogManagement
{
    public class Article : EntityBase
    {
        [Display(Name = "عنوان")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; private set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(1000,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string ShortDescription { get; private set; }

        [Display(Name = "توضیحات")]
        public string Description { get; private set; }

        [Display(Name = "عکس")]
        [MaxLength(500,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Picture { get; private set; }

        [Display(Name = "متن جایگذین عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureAlt { get; private set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string PictureTitle { get; private set; }

        [Display(Name = "تاریخ ارسال")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public DateTime PublishDate { get; private set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(600, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Slug { get; private set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Keywords { get; private set; }

        [Display(Name = "توضیحات مختصر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string MetaDescription { get; private set; }

        [Display(Name = "آدرس محتوا مشابه")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? CanonicalAddress { get; private set; }

        [Display(Name = "حذف شده")]
        public bool IsRemoved { get; set; }

        public long CategoryId { get; private set; }
        [ForeignKey("CategoryId")]
        public ArticleCategory Category { get; private set; }

        public Article(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string slug,
            string keywords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            IsRemoved=false;
        }

        public void Edit(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string slug,
            string keywords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
