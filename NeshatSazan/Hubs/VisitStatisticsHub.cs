using DataLayer.Context;
using DataLayer.Models.InformationManagement;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace NeshatSazan.Hubs
{
    public class VisitStatisticsHub : Hub
    {
        private readonly ApplicationDbContext dbContext;

        public VisitStatisticsHub(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task OnConnectedAsync()
        {
            // Send the current visit statistics to the connected client
            var uniqueVisitorsCount = await dbContext.Visits.GroupBy(v => v.IPAddress).CountAsync();
            await Clients.Caller.SendAsync("UpdateVisitStatistics", uniqueVisitorsCount);
            await base.OnConnectedAsync();
        }

        public async Task AddVisit(string ipAddress)
        {
            //    var visit = new Visit
            //    {
            //        IPAddress = ipAddress,
            //        VisitTime = DateTime.UtcNow,
            //        PageVisited = Context.GetHttpContext().Request.Path.ToString()
            //    };

            //    // Save the visit to the database
            //    dbContext.Visits.Add(visit);
            //    await dbContext.SaveChangesAsync();

            //    // Send updated visit statistics to all connected clients
            //    var uniqueVisitorsCount = await dbContext.Visits.GroupBy(v => v.IPAddress).CountAsync();
            //    await Clients.All.SendAsync("UpdateVisitStatistics", uniqueVisitorsCount);

            var visitTime = DateTime.Now.ToShortDateString();
            var pageVisited = Context.GetHttpContext().Request.Path.ToString();

            // Check if a visit with the same IP address and visit time already exists
            bool isDuplicate = await dbContext.Visits.AnyAsync(v =>
                v.IPAddress == ipAddress &&
                v.VisitTime == visitTime);

            if (!isDuplicate)
            {
                var visit = new Visit
                {
                    IPAddress = ipAddress,
                    VisitTime = visitTime,
                    PageVisited = pageVisited
                };

                // Save the visit to the database
                dbContext.Visits.Add(visit);
                await dbContext.SaveChangesAsync();
            }

            // Update visit statistics for all connected clients
            var uniqueVisitorsCount = await dbContext.Visits.GroupBy(v => v.IPAddress).CountAsync();
            await Clients.All.SendAsync("UpdateVisitStatistics", uniqueVisitorsCount);



        }
    }
}
