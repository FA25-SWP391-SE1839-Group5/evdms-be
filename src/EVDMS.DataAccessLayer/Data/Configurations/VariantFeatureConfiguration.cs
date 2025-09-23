using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VariantFeatureConfiguration : IEntityTypeConfiguration<VariantFeature>
    {
        public void Configure(EntityTypeBuilder<VariantFeature> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(vf => vf.VehicleVariant)
                .WithMany(vv => vv.VariantFeatures)
                .HasForeignKey(vf => vf.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(vf => vf.Feature)
                .WithMany(f => f.VariantFeatures)
                .HasForeignKey(vf => vf.FeatureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
