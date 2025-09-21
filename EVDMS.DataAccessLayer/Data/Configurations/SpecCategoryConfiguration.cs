using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SpecCategoryConfiguration : IEntityTypeConfiguration<SpecCategory>
    {
        public void Configure(EntityTypeBuilder<SpecCategory> builder)
        {
            builder.ConfigureTimestamps();
            builder.HasData(SpecCategorySeed.SpecCategories);
        }
    }
}
