using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VariantFeatureConfiguration : IEntityTypeConfiguration<VariantFeature>
    {
        public void Configure(EntityTypeBuilder<VariantFeature> builder)
        {
            builder.HasKey(vf => vf.Id);
            builder.Property(vf => vf.IsAvailable).IsRequired();
            builder.Property(vf => vf.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(vf => vf.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
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
