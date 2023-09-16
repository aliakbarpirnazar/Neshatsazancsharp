using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NeshatSazan.Hubs;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi;

namespace NeshatSazan.Controllers
{
	public class HomeController : Controller
    {

		private readonly IQueryClients _Iquery;
	
		private readonly IHubContext<VisitStatisticsHub> visitStatisticsHubContext;
        private readonly ILogger<HomeController> _logger;
		public HomeController(ILogger<HomeController> logger, IHubContext<VisitStatisticsHub> visitStatisticsHubContext, IQueryClients iquery)
		{
			_logger = logger;
			this.visitStatisticsHubContext = visitStatisticsHubContext;
			_Iquery = iquery;
		}

		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Information Site && Company
        [HttpGet]
        public IActionResult Company()
        {
            var info = new SiteInfoHomeViewModel
            {
                Siteinfo = _Iquery.GetCompanyInfoFarsi(),
                ChartDesigns = _Iquery.GetChartDesignHomeFarsi(),
                ChartPic = _Iquery.GetChartPicHomeFarsi(),
            };	

			return View(info);
        }  
        
        //Clip And Podcast
        [HttpGet]
        public IActionResult ClipAndPodcast()
        {
            var info = _Iquery.GetClipHomeFarsi();
			return View(info);
        }

        [HttpGet]
        public IActionResult Podcast(string Slug)
        {
            var info = _Iquery.GetPodcastHomeFarsi(Slug);
			return View(info);
        }

        //Blog And CategoryBlog.... 

        [HttpGet]
        public IActionResult CategoryArticle()
        {
            var model = _Iquery.GetArticleCategoryHomeFarsi();
            return View(model);
        }

		[HttpGet]
		public IActionResult ArticleCategory(string slug)
        {
			var model = _Iquery.GetArticlesHomeFarsi(slug);
            var Articlecategory = _Iquery.GetArticleCategoryHomeFarsi(slug);
            ViewBag.Name = Articlecategory.Name;

            return View(model);
		}

        [HttpGet]
		public IActionResult Article(string slug)
        {
			var model = _Iquery.GetArticleHomeFarsi(slug);
            ViewBag.Day = model.PublishDate.ToFarsiDay();
            ViewBag.Month = model.PublishDate.ToFarsiMonth();
            return View(model);
		}

		//Contact us 

		[HttpGet]
        public IActionResult Contact()
        {
            var model = _Iquery.GetSiteInfoHomeFarsi();
            return View(model);
        }

		//Certificates

		[HttpGet]
		public IActionResult Certificates()
		{
			var info = _Iquery.GetCertificateHomeFarsi();
			return View(info);
		}


        //NewsSites

        [HttpGet]
        public IActionResult News()
        {
            var info = _Iquery.GetNewsSiteHomeFarsi();
            return View(info);
        } 

        [HttpGet]
        public IActionResult NewsSearch(string slug)
        {
            var info = _Iquery.GetNewsSiteHomeFarsi(slug);
			ViewBag.Day = info.StartDate.ToFarsiDay();
			ViewBag.Month = info.StartDate.ToFarsiMonth();
			return View(info);
        }


        //Projects

        [HttpGet]
        public IActionResult Projects()
        {
            var info = _Iquery.GetProjectsHomeFarsi();
            return View(info);
        }

        [HttpGet]
        public IActionResult Project(string slug)
        {
            var info = _Iquery.GetProjectsHomeFarsi(slug);
            ViewBag.startDate = info.StartDate.ToFarsi();
            ViewBag.EndDate = info.EndDate.ToFarsi();
            return View(info);
        }




        //Save Views Site
        [HttpPost]
        public IActionResult RecordVisit(string ipAddress)
        {
            visitStatisticsHubContext.Clients.All.SendAsync("AddVisit", ipAddress);
            return Ok();
        }
      
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}