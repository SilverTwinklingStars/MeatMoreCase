using System.Threading.Tasks;

namespace MeatMoreCase.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        Task SaveChangesAsync();
    }
}
