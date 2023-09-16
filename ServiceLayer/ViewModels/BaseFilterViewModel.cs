namespace ServiceLayer.ViewModels
{
    public class BaseFilterViewModel<T>
    {
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }

        private IEnumerable<T> entities;
        public IEnumerable<T> Entities { get { return entities; } set { entities = value; } }
    }
}
