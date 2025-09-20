using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerAllocationConfiguration : IEntityTypeConfiguration<DealerAllocation>
    {
        public void Configure(EntityTypeBuilder<DealerAllocation> builder)
        {
            builder.HasKey(da => da.Id);
            builder.Property(da => da.AllocationDate).IsRequired();
            builder.Property(da => da.Status).IsRequired();
            builder.Property(da => da.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(da => da.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(da => da.Dealer)
                .WithMany(d => d.DealerAllocations)
                .HasForeignKey(da => da.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(da => da.Vehicle)
                .WithMany(v => v.DealerAllocations)
                .HasForeignKey(da => da.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
