using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.BlogManagement;
using DataLayer.Models.CertificateManagement;
using DataLayer.Models.InformationManagement;
using DataLayer.Models.NewsManagement;
using DataLayer.Models.ProjectManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi;
using ServiceLayer.ViewModels.Client.Farsi.Footer;
using ServiceLayer.ViewModels.Client.Farsi.Menu;

namespace ServiceLayer.Services
{
	public class QueryClientsService : IQueryClients
    {
        private readonly ApplicationDbContext _context;

        public QueryClientsService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Farsi Menu Management
        public SiteInfoMenu GetSiteInfoFarsiMenus()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "0");
            SiteInfoMenu model = new SiteInfoMenu()
            {
                TelNumber = Siteinfo.TelNumber,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram = Siteinfo.LinkTelegram,
                LinkWhatsApp = Siteinfo.LinkWhatsApp,
            };

            return model;
        }
        public SettingsMenuViewModel GetSettingsFarsiMenus()
        {
            var setting = _context.Settings.FirstOrDefault(x => x.Language == "0");
            SettingsMenuViewModel model = new SettingsMenuViewModel()
            {
                LogoStr = setting.Logo,
                LogoAlt = setting.LogoAlt,
                LogoTitle = setting.LogoTitle,
            };

            return model;
        }
        public List<SliderViewModel> GetSlideFarsi()
        {
            var sellerList = _context.SlideHeaders.Where(x => x.IsRemoved == false && x.Language == "0").OrderByDescending(x => x.Id).ToList();
            var resault = sellerList.Select(x => new SliderViewModel
            {
                Title = x.Title,
                Heading = x.Heading,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
            }).ToList();
            return resault;
        }
        public SiteInfViewModel GetSiteInfoFarsi()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "0");
            SiteInfViewModel model = new SiteInfViewModel()
            {
                Qusetion = Siteinfo.Qusetion,
                MetaDescription = Siteinfo.MetaDescription,
                ShortDescription = Siteinfo.ShortDescription,
            };

            return model;
        }
        public List<NewsSiteViewModel> GetNewsSiteFarsi()
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == false && x.Language == "0").OrderByDescending(x => x.Id).Take(4).ToList();
            var resault = sellerList.Select(x => new NewsSiteViewModel
            {
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.StartDate.ToFarsi(),
                StartDay = x.StartDate.ToFarsiDay(),
                StartMonth = x.StartDate.ToFarsiMonth(),
            }).ToList();
            return resault;
        }
        public List<ProjectsHomeViewModel> GetProjectsFarsi()
        {
            var sellerList = _context.Projects.Where(x => x.IsRemoved == false && x.Language == "0").OrderByDescending(x => x.Id).Take(4).ToList();
            var resault = sellerList.Select(x => new ProjectsHomeViewModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                NumberUnit = x.NumberUnit,
                StartDate = x.StartDate.ToFarsi(),
                Title = x.Title,
                TypeStructureProject = x.TypeStructureProject
            }).ToList();
            return resault;
        }
        public List<QuestionsHomeViewModel> GetQuestionsFarsi()
        {
            var sellerList = _context.AskedQuestions.Where(x => x.IsRemoved == false && x.Language == "0").OrderBy(x => x.OrderBy).ToList();
            var resault = sellerList.Select(x => new QuestionsHomeViewModel
            {
                Answer = x.Answer,
                Qusetion = x.Qusetion,

            }).ToList();
            return resault;
        }
        public List<blogHomeViewModel> GetBlogFarsi()
        {
            var articles = _context.Articles.Include(x => x.Category).Where(x => x.IsRemoved == false && x.Category.Language == "0").OrderByDescending(x => x.Id).Take(3).ToList();
            var resault = articles.Select(x => new blogHomeViewModel
            {
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.CreationDate.ToFarsi(),
                StartDay = x.CreationDate.ToFarsiDay(),
                StartMonth = x.CreationDate.ToFarsiMonth(),
                GropArticle = x.Category.Name,
            }).ToList();
            return resault;


        }
        public List<ArticleCategoryMenuViewModel> GetArticleCategoryFarsi()
        {
            var articles = _context.ArticleCategories.Where(x => x.IsRemoved == false && x.Language == "0").OrderByDescending(x => x.Id).Take(8).ToList();
            var resault = articles.Select(x => new ArticleCategoryMenuViewModel
            {
                Name = x.Name,
                Slug = x.Slug,
            }).ToList();
            return resault;


        }
        public SiteInfoFooter GetSiteInfoFarsiFooter()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "0");
            SiteInfoFooter model = new SiteInfoFooter()
            {
                TelNumber = Siteinfo.TelNumber,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram = Siteinfo.LinkTelegram,
                LinkWhatsApp = Siteinfo.LinkWhatsApp,
                Address = Siteinfo.Address,
                LinkLocation = Siteinfo.LinkLocation,
            };

            return model;
        }
        public SiteInfo GetCompanyInfoFarsi()
        {
            var Sinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "0");
            SiteInfo info = new SiteInfo()
            {
                Address = Sinfo.Address,
                CreationDate = Sinfo.CreationDate,
                Description = Sinfo.Description,
                Language = Sinfo.Language,
                Linkinstagram = Sinfo.Linkinstagram,
                LinkLocation = Sinfo.LinkLocation,
                LinkTelegram = Sinfo.LinkTelegram,
                LinkWhatsApp = Sinfo.LinkWhatsApp,
                MetaDescription = Sinfo.MetaDescription,
                MissionCompany = Sinfo.MissionCompany,
                Picture = Sinfo.Picture,
                PictureAlt = Sinfo.PictureAlt,
                PictureTitle = Sinfo.PictureTitle,
                Qusetion = Sinfo.Qusetion,
                ShortDescription = Sinfo.ShortDescription,
                TelNumber = Sinfo.TelNumber,
                TimeRun = Sinfo.TimeRun,
                VisionCompany = Sinfo.VisionCompany,
            };
            return info;
        }
        public List<ChartDesign> GetChartDesignHomeFarsi()
        {
            var articles = _context.ChartDesigns.Where(x => x.IsRemove == false && x.Language == "0").OrderBy(x => x.Id).ToList();
            var resault = articles.Select(x => new ChartDesign
            {
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                CreationDate = x.CreationDate,
                IsRemove = x.IsRemove,
                Language = x.Language,
                NameFamily = x.NameFamily,
                SideCompany = x.SideCompany
            }).ToList();
            return resault;
        }
        public ChartPicture GetChartPicHomeFarsi()
        {
            var Sinfo = _context.ChartPictures.FirstOrDefault(x => x.Language == "0");
            ChartPicture info = new ChartPicture()
            {
                Language = Sinfo.Language,
                Picture = Sinfo.Picture,
                PictureAlt = Sinfo.PictureAlt,
                PictureTitle = Sinfo.PictureTitle,
                CreationDate = Sinfo.CreationDate,
            };
            return info;
        }
        public List<ClipAndPodcastHomeViewModel> GetClipHomeFarsi()
        {
            var Sinfo = _context.Podcasts.OrderByDescending(x => x.Id).Where(x => x.Language == "0" && x.IsRemoved == false);
            var info = Sinfo.Select(x => new ClipAndPodcastHomeViewModel
            {
                Slug = x.Slug,
                Title = x.Title,
                Video = x.Video,
                pictureAlt = x.PictureAlt,
                pictureTitle = x.PictureTitle,
                picture = x.Picture,
            }).ToList();

            return info;
        }
        public podcastHomeViewModel GetPodcastHomeFarsi(string slug)
        {
            var Siteinfo = _context.Podcasts.FirstOrDefault(x => x.Slug == slug);
            podcastHomeViewModel model = new podcastHomeViewModel()
            {
                Title = Siteinfo.Slug,
                Video = Siteinfo.Video,
            };

            return model;
        }
        public SiteInfoHomeFarsi GetSiteInfoHomeFarsi()
        {
			var Sinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "0");
			SiteInfoHomeFarsi info = new SiteInfoHomeFarsi()
			{
                Address=Sinfo.Address,
                Linkinstagram=Sinfo.Linkinstagram,
                LinkLocation=Sinfo.LinkLocation,
                LinkTelegram=Sinfo.LinkTelegram,    
                LinkWhatsApp = Sinfo.LinkWhatsApp,
                MetaDescription = Sinfo.MetaDescription,
                ShortDescription= Sinfo.ShortDescription,
                TelNumber=Sinfo.TelNumber,
                TimeRun = Sinfo.TimeRun,
			};
			return info;

		}
        public List<ArticleCategoryHomeViewModel> GetArticleCategoryHomeFarsi()
        {
            var Sinfo = _context.ArticleCategories.OrderByDescending(x => x.CreationDate).Where(x => x.Language == "0" && x.IsRemoved == false);
            var info = Sinfo.Select(x => new ArticleCategoryHomeViewModel
            {
                Slug=x.Slug,
                CanonicalAddress=x.CanonicalAddress,
                StartDate = x.CreationDate.ToFarsi(),
                StartDay = x.CreationDate.ToFarsiDay(),
                StartMonth = x.CreationDate.ToFarsiMonth(),
                ShowOrder=x.ShowOrder,
                Description=x.Description,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Name=x.Name,
                Picture = x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureAlt,
            }).ToList();

            return info;
        }		
		public List<blogHomeViewModel> GetArticlesHomeFarsi(string slug)
		{
			var articles = _context.Articles.Include(x => x.Category).Where(x => x.IsRemoved == false && x.Category.Slug == slug).OrderByDescending(x => x.Id).ToList();
			var resault = articles.Select(x => new blogHomeViewModel
			{
				MetaDescription = x.MetaDescription,
				Picture = x.Picture,
				PictureAlt = x.PictureAlt,
				PictureTitle = x.PictureTitle,
				Slug = x.Slug,
				Title = x.Title,
				StartDate = x.CreationDate.ToFarsi(),
				StartDay = x.CreationDate.ToFarsiDay(),
				StartMonth = x.CreationDate.ToFarsiMonth(),
				GropArticle = x.Category.Name,
			}).ToList();
			return resault;
		}
        public ArticleCategory GetArticleCategoryHomeFarsi(string slug)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Slug == slug);
        }
        public Article GetArticleHomeFarsi(string slug)
        {
            return _context.Articles.Include(x=>x.Category).Where(x=>x.IsRemoved == false).FirstOrDefault(x => x.Slug == slug);
        }
        public List<Certificate> GetCertificateHomeFarsi()
        {
            return _context.Certificates.Where(x => x.IsRemoved == false).OrderByDescending(x => x.CreationDate).ToList();            
        }
        public List<NewsSiteViewModel> GetNewsSiteHomeFarsi()
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == false && x.Language == "0").OrderByDescending(x => x.StartDate).ToList();
            var resault = sellerList.Select(x => new NewsSiteViewModel
            {
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.StartDate.ToFarsi(),
                StartDay = x.StartDate.ToFarsiDay(),
                StartMonth = x.StartDate.ToFarsiMonth(),
            }).ToList();
            return resault;
        }
        public NewsSite GetNewsSiteHomeFarsi(string slug)
        {
            return _context.NewsSites.Include(x=>x.sliderNewsSites).Include(x=>x.videoNewsSites).OrderBy(x=>x.CreationDate).FirstOrDefault(x => x.Slug == slug);
        }
        public List<Project> GetProjectsHomeFarsi()
        {
            return _context.Projects.OrderByDescending(x=>x.StartDate).Where(x=>x.IsRemoved == false && x.Language=="0").ToList();
        }
        public Project GetProjectsHomeFarsi(string slug)
        {
            return _context.Projects.Include(x => x.sliderProjects).FirstOrDefault(x => x.Slug == slug);
        }

        //Enghlish Menu Management
        public SiteInfoMenu GetSiteInfoEnMenus()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfoMenu model = new SiteInfoMenu()
            {
                TelNumber = Siteinfo.TelNumber,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram = Siteinfo.LinkTelegram,
                LinkWhatsApp = Siteinfo.LinkWhatsApp,
            };

            return model;
        }
        public SettingsMenuViewModel GetSettingsEnMenus()
        {
            var setting = _context.Settings.FirstOrDefault(x => x.Language == "1");
            SettingsMenuViewModel model = new SettingsMenuViewModel()
            {
                LogoStr = setting.Logo,
                LogoAlt = setting.LogoAlt,
                LogoTitle = setting.LogoTitle,
            };

            return model;
        }
        public List<SliderViewModel> GetSlideEn()
        {
            var sellerList = _context.SlideHeaders.Where(x => x.IsRemoved == false && x.Language == "1").OrderByDescending(x => x.Id).ToList();
            var resault = sellerList.Select(x => new SliderViewModel
            {
                Title = x.Title,
                Heading = x.Heading,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
            }).ToList();
            return resault;
        }
        public SiteInfViewModel GetSiteInfoEn()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfViewModel model = new SiteInfViewModel()
            {
                Qusetion = Siteinfo.Qusetion,
                MetaDescription = Siteinfo.MetaDescription,
                ShortDescription = Siteinfo.ShortDescription,
            };

            return model;
        }
        public List<NewsSiteViewModel> GetNewsSiteEn()
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == false && x.Language == "1").OrderByDescending(x => x.Id).Take(4).ToList();
            var resault = sellerList.Select(x => new NewsSiteViewModel
            {
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.StartDate.ToString(),
                StartDay = x.StartDate.Day.ToString(),
                StartMonth = x.StartDate.Month.ToString(),
            }).ToList();
            return resault;
        }
        public List<ProjectsHomeViewModel> GetProjectsEn()
        {
            var sellerList = _context.Projects.Where(x => x.IsRemoved == false && x.Language == "1").OrderByDescending(x => x.Id).Take(6).ToList();
            var resault = sellerList.Select(x => new ProjectsHomeViewModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
            }).ToList();
            return resault;
        }
        public List<QuestionsHomeViewModel> GetQuestionsEn()
        {
            var sellerList = _context.AskedQuestions.Where(x => x.IsRemoved == false && x.Language == "1").OrderBy(x => x.OrderBy).ToList();
            var resault = sellerList.Select(x => new QuestionsHomeViewModel
            {
                Answer = x.Answer,
                Qusetion = x.Qusetion,

            }).ToList();
            return resault;
        }
        public List<blogHomeViewModel> GetBlogEn()
        {
            var articles = _context.Articles.Include(x => x.Category).Where(x => x.IsRemoved == false && x.Category.Language == "1").OrderByDescending(x => x.Id).Take(3).ToList();
            var resault = articles.Select(x => new blogHomeViewModel
            {
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.CreationDate.ToString(),
                StartDay = x.CreationDate.Day.ToString(),
                StartMonth = x.CreationDate.Month.ToString(),
                GropArticle = x.Category.Name,
            }).ToList();
            return resault;


        }
        public List<ArticleCategoryMenuViewModel> GetArticleCategoryEn()
        {
            var articles = _context.ArticleCategories.Where(x => x.IsRemoved == false && x.Language == "1").OrderByDescending(x => x.Id).Take(8).ToList();
            var resault = articles.Select(x => new ArticleCategoryMenuViewModel
            {
                Name = x.Name,
                Slug = x.Slug,
            }).ToList();
            return resault;


        }
        public SiteInfoFooter GetSiteInfoEnFooter()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfoFooter model = new SiteInfoFooter()
            {
                TelNumber = Siteinfo.TelNumber,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram = Siteinfo.LinkTelegram,
                LinkWhatsApp = Siteinfo.LinkWhatsApp,
                Address = Siteinfo.Address,
                LinkLocation = Siteinfo.LinkLocation,
            };

            return model;
        }
        public SiteInfo GetCompanyInfoEn()
        {
            var Sinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfo info = new SiteInfo()
            {
                Address = Sinfo.Address,
                CreationDate = Sinfo.CreationDate,
                Description = Sinfo.Description,
                Language = Sinfo.Language,
                Linkinstagram = Sinfo.Linkinstagram,
                LinkLocation = Sinfo.LinkLocation,
                LinkTelegram = Sinfo.LinkTelegram,
                LinkWhatsApp = Sinfo.LinkWhatsApp,
                MetaDescription = Sinfo.MetaDescription,
                MissionCompany = Sinfo.MissionCompany,
                Picture = Sinfo.Picture,
                PictureAlt = Sinfo.PictureAlt,
                PictureTitle = Sinfo.PictureTitle,
                Qusetion = Sinfo.Qusetion,
                ShortDescription = Sinfo.ShortDescription,
                TelNumber = Sinfo.TelNumber,
                TimeRun = Sinfo.TimeRun,
                VisionCompany = Sinfo.VisionCompany,
            };
            return info;
        }
        public List<ChartDesign> GetChartDesignHomeEn()
        {
            var articles = _context.ChartDesigns.Where(x => x.IsRemove == false && x.Language == "1").OrderBy(x => x.Id).ToList();
            var resault = articles.Select(x => new ChartDesign
            {
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                CreationDate = x.CreationDate,
                IsRemove = x.IsRemove,
                Language = x.Language,
                NameFamily = x.NameFamily,
                SideCompany = x.SideCompany
            }).ToList();
            return resault;
        }
        public ChartPicture GetChartPicHomeEn()
        {
            var Sinfo = _context.ChartPictures.FirstOrDefault(x => x.Language == "1");
            ChartPicture info = new ChartPicture()
            {
                Language = Sinfo.Language,
                Picture = Sinfo.Picture,
                PictureAlt = Sinfo.PictureAlt,
                PictureTitle = Sinfo.PictureTitle,
                CreationDate = Sinfo.CreationDate,
            };
            return info;
        }
        public List<ClipAndPodcastHomeViewModel> GetClipHomeEn()
        {
            var Sinfo = _context.Podcasts.OrderByDescending(x => x.Id).Where(x => x.Language == "1" && x.IsRemoved == false);
            var info = Sinfo.Select(x => new ClipAndPodcastHomeViewModel
            {
                Slug = x.Slug,
                Title = x.Title,
                Video = x.Video,
                pictureAlt = x.PictureAlt,
                pictureTitle = x.PictureTitle,
                picture = x.Picture,
            }).ToList();

            return info;
        }
        public podcastHomeViewModel GetPodcastHomeEn(string slug)
        {
            var Siteinfo = _context.Podcasts.FirstOrDefault(x => x.Slug == slug);
            podcastHomeViewModel model = new podcastHomeViewModel()
            {
                Title = Siteinfo.Slug,
                Video = Siteinfo.Video,
            };

            return model;
        }
        public SiteInfoHomeFarsi GetSiteInfoHomeEn()
        {
            var Sinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfoHomeFarsi info = new SiteInfoHomeFarsi()
            {
                Address = Sinfo.Address,
                Linkinstagram = Sinfo.Linkinstagram,
                LinkLocation = Sinfo.LinkLocation,
                LinkTelegram = Sinfo.LinkTelegram,
                LinkWhatsApp = Sinfo.LinkWhatsApp,
                MetaDescription = Sinfo.MetaDescription,
                ShortDescription = Sinfo.ShortDescription,
                TelNumber = Sinfo.TelNumber,
                TimeRun = Sinfo.TimeRun,
            };
            return info;

        }
        public List<ArticleCategoryHomeViewModel> GetArticleCategoryHomeEn()
        {
            var Sinfo = _context.ArticleCategories.OrderByDescending(x => x.CreationDate).Where(x => x.Language == "1" && x.IsRemoved == false);
            var info = Sinfo.Select(x => new ArticleCategoryHomeViewModel
            {
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                StartDate = x.CreationDate.ToString(),
                StartDay = x.CreationDate.Day.ToString(),
                StartMonth = x.CreationDate.Month.ToString(),
                ShowOrder = x.ShowOrder,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureAlt,
            }).ToList();

            return info;
        }
        public List<blogHomeViewModel> GetArticlesHomeEn(string slug)
        {
            var articles = _context.Articles.Include(x => x.Category).Where(x => x.IsRemoved == false && x.Category.Slug == slug).OrderByDescending(x => x.Id).ToList();
            var resault = articles.Select(x => new blogHomeViewModel
            {
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.CreationDate.ToString(),
                StartDay = x.CreationDate.Day.ToString(),
                StartMonth = x.CreationDate.Month.ToString(),
                GropArticle = x.Category.Name,
            }).ToList();
            return resault;
        }
        public ArticleCategory GetArticleCategoryHomeEn(string slug)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Slug == slug);
        }
        public Article GetArticleHomeEn(string slug)
        {
            return _context.Articles.Include(x => x.Category).Where(x => x.IsRemoved == false).FirstOrDefault(x => x.Slug == slug);
        }
        public List<Certificate> GetCertificateHomeEn()
        {
            return _context.Certificates.Where(x => x.IsRemoved == false).OrderByDescending(x => x.CreationDate).ToList();
        }
        public List<NewsSiteViewModel> GetNewsSiteHomeEn()
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == false && x.Language == "1").OrderByDescending(x => x.StartDate).ToList();
            var resault = sellerList.Select(x => new NewsSiteViewModel
            {
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                StartDate = x.StartDate.ToString(),
                StartDay = x.StartDate.Day.ToString(),
                StartMonth = x.StartDate.Month.ToString(),
            }).ToList();
            return resault;
        }
        public NewsSite GetNewsSiteHomeEn(string slug)
        {
            return _context.NewsSites.Include(x => x.sliderNewsSites).Include(x => x.videoNewsSites).OrderBy(x => x.CreationDate).FirstOrDefault(x => x.Slug == slug);
        }
        public List<Project> GetProjectsHomeEn()
        {
            return _context.Projects.OrderByDescending(x => x.StartDate).Where(x => x.IsRemoved == false && x.Language == "1").ToList();
        }
        public Project GetProjectsHomeEn(string slug)
        {
            return _context.Projects.Include(x => x.sliderProjects).FirstOrDefault(x => x.Slug == slug);
        }

    }
}
