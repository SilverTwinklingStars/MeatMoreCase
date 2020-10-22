using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MeatMoreCase.Data.Repositories
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        private readonly DbSet<Day> _days;

        public DayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _days = dbContext.Days;
        }

        public async ValueTask<Day> GetDayByDate(DateTime date)
        {
            return await _days.FirstOrDefaultAsync(d => d.Date.Date == date.Date);
        }
    }
}
