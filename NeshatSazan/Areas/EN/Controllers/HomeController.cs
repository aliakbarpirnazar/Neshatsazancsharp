using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NeshatSazan.Hubs;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Client.Farsi;

namespace NeshatSazan.Areas.EN.Controllers
{
	[Area(nameof(EN))]
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
				Siteinfo = _Iquery.GetCompanyInfoEn(),
				ChartDesigns = _Iquery.GetChartDesignHomeEn(),
				ChartPic = _Iquery.GetChartPicHomeEn(),
			};

			return View(info);
		}

		//Clip And Podcast
		[HttpGet]
		public IActionResult ClipAndPodcast()
		{
			var info = _Iquery.GetClipHomeEn();
			return View(info);
		}

		[HttpGet]
		public IActionResult Podcast(string Slug)
		{
			var info = _Iquery.GetPodcastHomeEn(Slug);
			return View(info);
		}

		//Blog And CategoryBlog.... 

		[HttpGet]
		public IActionResult CategoryArticle()
		{
			var model = _Iquery.GetArticleCategoryHomeEn();
			return View(model);
		}

		[HttpGet]
		public IActionResult ArticleCategory(string slug)
		{
			var model = _Iquery.GetArticlesHomeFarsi(slug);
			var Articlecategory = _Iquery.GetArticleCategoryHomeEn(slug);
			ViewBag.Name = Articlecategory.Name;

			return View(model);
		}

		[HttpGet]
		public IActionResult Article(string slug)
		{
			var model = _Iquery.GetArticleHomeEn(slug);
			ViewBag.Day = model.PublishDate.Day.ToString();
			ViewBag.Month = model.PublishDate.Month.ToString();
			return View(model);
		}

		//Contact us 

		[HttpGet]
		public IActionResult Contact()
		{
			var model = _Iquery.GetSiteInfoHomeEn();
			return View(model);
		}

		//Certificates

		[HttpGet]
		public IActionResult Certificates()
		{
			var info = _Iquery.GetCertificateHomeEn();
			return View(info);
		}


		//NewsSites

		[HttpGet]
		public IActionResult News()
		{
			var info = _Iquery.GetNewsSiteHomeEn();
			return View(info);
		}

		[HttpGet]
		public IActionResult NewsSearch(string slug)
		{
			var info = _Iquery.GetNewsSiteHomeEn(slug);
			ViewBag.Day = info.StartDate.Day.ToString();
			ViewBag.Month = info.StartDate.Month.ToString();
			return View(info);
		}


		//Projects

		[HttpGet]
		public IActionResult Projects()
		{
			var info = _Iquery.GetProjectsHomeEn();
			return View(info);
		}

		[HttpGet]
		public IActionResult Project(string slug)
		{
			var info = _Iquery.GetProjectsHomeEn(slug);
			ViewBag.startDate = info.StartDate.ToShortDateString();
			ViewBag.EndDate = info.EndDate.ToString();
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
