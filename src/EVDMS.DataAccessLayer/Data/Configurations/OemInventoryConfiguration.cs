using EVDMS.DataAccessLayer.Data.Seeds;
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
                .HasOne(oi => oi.VehicleVariant)
                .WithMany(vv => vv.OemInventories)
                .HasForeignKey(oi => oi.VariantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(OemInventorySeed.OemInventories);
        }
    }
}
