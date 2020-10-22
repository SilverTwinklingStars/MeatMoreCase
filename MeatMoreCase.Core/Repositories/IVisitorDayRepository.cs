using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeatMoreCase.Core.Repositories
{
    public interface IVisitorDayRepository : IRepository<VisitorDay>
    {
        ValueTask<IEnumerable<VisitorDay>> GetVisitorDays(VisitorDayParameters parameters = null);
        ValueTask<VisitorDay> GetVisitorDay(VisitorDayParameters parameters);
    }
}
