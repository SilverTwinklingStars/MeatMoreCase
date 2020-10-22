using MeatMoreCase.Core.Models;
using System;
using System.Threading.Tasks;

namespace MeatMoreCase.Core.Repositories
{
    public interface IDayRepository : IRepository<Day>
    {
        ValueTask<Day> GetDayByDate(DateTime date);
    }
}
