using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class FeatureCategoryConfiguration : IEntityTypeConfiguration<FeatureCategory>
    {
        public void Configure(EntityTypeBuilder<FeatureCategory> builder)
        {
            builder.ConfigureTimestamps();
            builder.HasData(FeatureCategorySeed.FeatureCategories);
        }
    }
}
