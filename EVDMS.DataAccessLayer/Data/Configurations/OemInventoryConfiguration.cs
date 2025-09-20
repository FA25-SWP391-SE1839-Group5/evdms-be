using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class OemInventoryConfiguration : IEntityTypeConfiguration<OemInventory>
    {
        public void Configure(EntityTypeBuilder<OemInventory> builder)
        {
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Location).IsRequired();
            builder.Property(oi => oi.Status).IsRequired();
            builder.Property(oi => oi.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(oi => oi.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(oi => oi.Vehicle)
                .WithMany(v => v.OemInventories)
                .HasForeignKey(oi => oi.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
