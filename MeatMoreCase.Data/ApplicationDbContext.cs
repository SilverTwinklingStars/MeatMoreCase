using MeatMoreCase.Core.Models;
using MeatMoreCase.Data.Mappers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeatMoreCase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<VisitorDay> VisitorDays { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new VisitorConfiguration());
            builder.ApplyConfiguration(new DayConfiguration());
            builder.ApplyConfiguration(new VisitorDayConfiguration());
        }
    }
}
