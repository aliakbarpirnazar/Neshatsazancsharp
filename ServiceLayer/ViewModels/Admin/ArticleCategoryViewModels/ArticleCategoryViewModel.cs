using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int ShowOrder { get; set; }
        public string CreationDate { get; set; }
        public long ArticlesCount { get; set; }
        public string Language { get; set; }
        public bool IsRemoved { get; set; }
    }


}
