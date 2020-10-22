using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Parameters;
using MeatMoreCase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeatMoreCase.Data.Repositories
{
    public class VisitorDayRepository : Repository<VisitorDay>, IVisitorDayRepository
    {
        private readonly DbSet<VisitorDay> _visitorDays;

        public VisitorDayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _visitorDays = dbContext.VisitorDays;
        }

        public async ValueTask<IEnumerable<VisitorDay>> GetVisitorDays(VisitorDayParameters parameters = null)
        {
            var visitorDays = _visitorDays.AsQueryable();

            if (parameters != null)
            {
                if (parameters.VisitorId > 0)
                    visitorDays = visitorDays.Where(vd => vd.VisitorId == parameters.VisitorId);
                if (parameters.DayId > 0)
                    visitorDays = visitorDays.Where(vd => vd.DayId == parameters.DayId);
                if (!string.IsNullOrEmpty(parameters.LastName))
                    visitorDays = visitorDays.Where(vd => vd.Visitor.LastName.ToLower() == parameters.LastName.ToLower());
                if (!string.IsNullOrEmpty(parameters.FirstName))
                    visitorDays = visitorDays.Where(vd => vd.Visitor.FirstName.ToLower() == parameters.FirstName.ToLower());
                if (parameters.Date.HasValue)
                    visitorDays = visitorDays.Where(vd => vd.Day.Date.Date == parameters.Date.Value.Date);
                if (parameters.VisitorDayState == VisitorDayState.Inside)
                    visitorDays = visitorDays.Where(vd => vd.Departure == null);
                else if (parameters.VisitorDayState == VisitorDayState.Left)
                    visitorDays = visitorDays.Where(vd => vd.Departure != null);
                if (parameters.Includes != null && parameters.Includes.Any())
                    parameters.Includes.ToList().ForEach(include => visitorDays = visitorDays.Include(include));
            }
            return await visitorDays.OrderByDescending(vd => vd.Day.Date).ToListAsync();
        }
        public async ValueTask<VisitorDay> GetVisitorDay(VisitorDayParameters parameters)
        {
            var result = await GetVisitorDays(parameters);
            return result.FirstOrDefault();
        }
    }
}
