using ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ArticleViewModels
{
    public class ArticleIndexViewModel : ArticleSearchModel
    {
        public List<ArticleViewModel> articleModels { get; set; }

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

    }
}
