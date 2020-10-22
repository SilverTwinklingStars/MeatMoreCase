using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeatMoreCase.Data.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        private readonly DbSet<Visitor> _visitors;
        public VisitorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _visitors = dbContext.Visitors;
        }

        public async ValueTask<Visitor> GetById(int visitorId)
        {
            return await _visitors.FirstOrDefaultAsync(v => v.VisitorId == visitorId);
        }
    }
}
