using MeatMoreCase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeatMoreCase.Data.Mappers
{
    public class VisitorDayConfiguration : IEntityTypeConfiguration<VisitorDay>
    {
        public void Configure(EntityTypeBuilder<VisitorDay> builder)
        {
            builder.ToTable("VisitorDays");

            builder.HasKey(vd => new { vd.VisitorId, vd.DayId });

            builder.Property(vd => vd.Arrival).IsRequired();

            builder.HasOne(vd => vd.Visitor).WithMany().IsRequired().HasForeignKey(vd => vd.VisitorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(vd => vd.Day).WithMany(d => d.VisitorDays).HasForeignKey(vd => vd.DayId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
