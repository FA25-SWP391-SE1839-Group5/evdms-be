using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class FeatureCategoryConfiguration : IEntityTypeConfiguration<FeatureCategory>
    {
        public void Configure(EntityTypeBuilder<FeatureCategory> builder)
        {
            builder.HasKey(fc => fc.Id);
            builder.Property(fc => fc.CategoryName).IsRequired();
            builder.Property(fc => fc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(fc => fc.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
