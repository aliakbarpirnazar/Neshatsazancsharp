using DataLayer.Models.InformationManagement;

namespace ServiceLayer.ViewModels.Client.Farsi
{
    public class SiteInfoHomeViewModel
	{
		public SiteInfo Siteinfo { get; set; }
		public ChartPicture ChartPic { get; set; }
		public List<ChartDesign> ChartDesigns { get; set; }
	}
}
