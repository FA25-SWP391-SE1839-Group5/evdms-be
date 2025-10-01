using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ConfigureTimestamps();
            builder.HasData(VehicleModelSeed.VehicleModels);
        }
    }
}
