namespace ServiceLayer.ViewModels.Client.Farsi.Menu
{
    public class MenuViewModel
    {
        public SiteInfoMenu siteInfoMenu { get; set; }
        public SettingsMenuViewModel SettingMenu { get; set; }
        public List<ArticleCategoryMenuViewModel> ArticleCategory { get; set; }
    }
}
