using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ConfigureTimestamps();
            builder.Property(v => v.Color).HasConversion<string>();
            builder.Property(v => v.Status).HasConversion<string>();
            builder.Property(v => v.Type).HasConversion<string>();
            builder
                .HasOne(v => v.VehicleVariant)
                .WithMany(vv => vv.Vehicles)
                .HasForeignKey(v => v.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(v => v.Dealer)
                .WithMany(d => d.Vehicles)
                .HasForeignKey(v => v.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(v => v.Vin).IsUnique();
        }
    }
}
