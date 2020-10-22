using MeatMoreCase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeatMoreCase.Data.Mappers
{
    public class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.ToTable("Days");

            builder.HasKey(d => d.DayId);

            builder.HasIndex(d => d.Date).IsUnique();
        }
    }
}
