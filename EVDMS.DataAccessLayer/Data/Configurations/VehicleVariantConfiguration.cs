using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleVariantConfiguration : IEntityTypeConfiguration<VehicleVariant>
    {
        public void Configure(EntityTypeBuilder<VehicleVariant> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(vv => vv.VehicleModel)
                .WithMany(vm => vm.VehicleVariants)
                .HasForeignKey(vv => vv.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(VehicleVariantSeed.VehicleVariants);
        }
    }
}
