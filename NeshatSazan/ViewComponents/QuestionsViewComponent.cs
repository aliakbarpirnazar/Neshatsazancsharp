using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.ViewComponents
{
    public class QuestionsViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public QuestionsViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetQuestionsFarsi();
            return View(slide);
        }
    }
}
