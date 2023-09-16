namespace DataLayer.Models.InformationManagement
{
    public class Visit
    {
        public long Id { get; set; }
        public string IPAddress { get; set; }
        public string PageVisited { get; set; }
        public string VisitTime { get; set; } = DateTime.Now.ToShortDateString();
    }
}
