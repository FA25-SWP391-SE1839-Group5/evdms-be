using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleVariantConfiguration : IEntityTypeConfiguration<VehicleVariant>
    {
        public void Configure(EntityTypeBuilder<VehicleVariant> builder)
        {
            builder.HasKey(vv => vv.Id);
            builder.Property(vv => vv.VariantName).IsRequired();
            builder.Property(vv => vv.BasePrice).IsRequired();
            builder.Property(vv => vv.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(vv => vv.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(vv => vv.VehicleModel)
                .WithMany(vm => vm.VehicleVariants)
                .HasForeignKey(vv => vv.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
