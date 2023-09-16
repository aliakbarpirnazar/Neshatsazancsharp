using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels.Client.Farsi
{
	public class ProjectsHomeViewModel
	{
        public string Title { get; set; }        
        public string StartDate { get; set; }
        public string TypeStructureProject { get; set; }
        public int NumberUnit { get; set; }

        public string Picture { get; set; }
		public string PictureAlt { get; set; }
		public string PictureTitle { get; set; }
		public string Slug { get; set; }

	}
}
