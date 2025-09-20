using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FeatureName).IsRequired();
            builder.Property(f => f.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(f => f.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(f => f.FeatureCategory)
                .WithMany(fc => fc.Features)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
