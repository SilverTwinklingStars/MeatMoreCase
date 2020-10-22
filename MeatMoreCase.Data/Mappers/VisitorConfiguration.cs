using MeatMoreCase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeatMoreCase.Data.Mappers
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitors");

            builder.HasKey(v => v.VisitorId);

            builder.Property(v => v.LastName).IsRequired().HasMaxLength(255);
            builder.Property(v => v.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(v => v.VisitType).IsRequired();
        }
    }
}
