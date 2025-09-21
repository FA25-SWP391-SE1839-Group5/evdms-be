using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class OemInventoryConfiguration : IEntityTypeConfiguration<OemInventory>
    {
        public void Configure(EntityTypeBuilder<OemInventory> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(oi => oi.Vehicle)
                .WithMany(v => v.OemInventories)
                .HasForeignKey(oi => oi.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
