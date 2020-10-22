using MeatMoreCase.Core.Models;
using System.Threading.Tasks;

namespace MeatMoreCase.Core.Repositories
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        ValueTask<Visitor> GetById(int visitorId);
    }
}
