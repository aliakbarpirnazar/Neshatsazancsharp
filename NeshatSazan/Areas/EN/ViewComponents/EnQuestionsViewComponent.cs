using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace NeshatSazan.Areas.EN.ViewComponents
{
    public class EnQuestionsViewComponent : ViewComponent
    {
        private readonly IQueryClients _Iquery;
        public EnQuestionsViewComponent(IQueryClients iquery)
        {
            _Iquery = iquery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _Iquery.GetQuestionsEn();
            return View(slide);
        }
    }
}
