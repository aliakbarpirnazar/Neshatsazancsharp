using DataLayer.Context;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class VisitService : IVisit
    {
        private readonly ApplicationDbContext _context;

        public VisitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetCountComplte()
        {
            return _context.Visits.Count();
        }
    }
}
