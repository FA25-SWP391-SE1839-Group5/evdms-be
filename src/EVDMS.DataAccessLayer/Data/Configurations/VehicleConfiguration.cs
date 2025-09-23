using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasIndex(v => v.Vin).IsUnique();
            builder.ConfigureTimestamps();
            builder
                .HasOne(v => v.VehicleVariant)
                .WithMany(vv => vv.Vehicles)
                .HasForeignKey(v => v.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(v => v.VehicleColor)
                .WithMany(vc => vc.Vehicles)
                .HasForeignKey(v => v.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
