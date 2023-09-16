using DataLayer.Models.BlogManagement;
using DataLayer.Models.CertificateManagement;
using DataLayer.Models.InformationManagement;
using DataLayer.Models.NewsManagement;
using DataLayer.Models.ProjectManagement;
using ServiceLayer.ViewModels.Client.Farsi;
using ServiceLayer.ViewModels.Client.Farsi.Footer;
using ServiceLayer.ViewModels.Client.Farsi.Menu;

namespace ServiceLayer.Interfaces
{
    public interface IQueryClients
    {
        SiteInfoMenu GetSiteInfoFarsiMenus();
        SettingsMenuViewModel GetSettingsFarsiMenus();
        SiteInfViewModel GetSiteInfoFarsi();
        List<SliderViewModel> GetSlideFarsi();
        List<NewsSiteViewModel> GetNewsSiteFarsi();
        List<blogHomeViewModel> GetBlogFarsi();
        List<ProjectsHomeViewModel> GetProjectsFarsi();
        List<QuestionsHomeViewModel> GetQuestionsFarsi();
        List<ArticleCategoryMenuViewModel> GetArticleCategoryFarsi();
        SiteInfoFooter GetSiteInfoFarsiFooter();
        SiteInfo GetCompanyInfoFarsi();
        ChartPicture GetChartPicHomeFarsi();
        List<ChartDesign> GetChartDesignHomeFarsi();
        List<ClipAndPodcastHomeViewModel> GetClipHomeFarsi();
        podcastHomeViewModel GetPodcastHomeFarsi(string slug);
        SiteInfoHomeFarsi GetSiteInfoHomeFarsi();
        List<ArticleCategoryHomeViewModel> GetArticleCategoryHomeFarsi();
        List<blogHomeViewModel> GetArticlesHomeFarsi(string slug);
        ArticleCategory GetArticleCategoryHomeFarsi(string slug);
        Article GetArticleHomeFarsi(string slug);
        List<Certificate> GetCertificateHomeFarsi();
        List<NewsSiteViewModel> GetNewsSiteHomeFarsi();
        NewsSite GetNewsSiteHomeFarsi(string slug);
        List<Project> GetProjectsHomeFarsi();
        Project GetProjectsHomeFarsi(string slug);


        //Enghlish

        SiteInfoMenu GetSiteInfoEnMenus();
        SettingsMenuViewModel GetSettingsEnMenus();
        SiteInfViewModel GetSiteInfoEn();
        List<SliderViewModel> GetSlideEn();
        List<NewsSiteViewModel> GetNewsSiteEn();
        List<blogHomeViewModel> GetBlogEn();
        List<ProjectsHomeViewModel> GetProjectsEn();
        List<QuestionsHomeViewModel> GetQuestionsEn();
        List<ArticleCategoryMenuViewModel> GetArticleCategoryEn();
        SiteInfoFooter GetSiteInfoEnFooter();
        SiteInfo GetCompanyInfoEn();
        ChartPicture GetChartPicHomeEn();
        List<ChartDesign> GetChartDesignHomeEn();
        List<ClipAndPodcastHomeViewModel> GetClipHomeEn();
        podcastHomeViewModel GetPodcastHomeEn(string slug);
        SiteInfoHomeFarsi GetSiteInfoHomeEn();
        List<ArticleCategoryHomeViewModel> GetArticleCategoryHomeEn();
        List<blogHomeViewModel> GetArticlesHomeEn(string slug);
        ArticleCategory GetArticleCategoryHomeEn(string slug);
        Article GetArticleHomeEn(string slug);
        List<Certificate> GetCertificateHomeEn();
        List<NewsSiteViewModel> GetNewsSiteHomeEn();
        NewsSite GetNewsSiteHomeEn(string slug);
        List<Project> GetProjectsHomeEn();
        Project GetProjectsHomeEn(string slug);







    }
}
