using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleColorConfiguration : IEntityTypeConfiguration<VehicleColor>
    {
        public void Configure(EntityTypeBuilder<VehicleColor> builder)
        {
            builder.ConfigureTimestamps();
            builder.HasData(VehicleColorSeed.VehicleColors);
        }
    }
}
