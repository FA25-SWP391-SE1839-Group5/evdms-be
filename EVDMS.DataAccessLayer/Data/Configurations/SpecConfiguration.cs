using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SpecConfiguration : IEntityTypeConfiguration<Spec>
    {
        public void Configure(EntityTypeBuilder<Spec> builder)
        {
            builder.ConfigureTimestamps();
            builder.HasData(SpecSeed.Specs);
        }
    }
}
