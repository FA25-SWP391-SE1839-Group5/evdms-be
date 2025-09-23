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
            builder.Property(vm => vm.Year).IsRequired();
            builder.HasData(VehicleModelSeed.VehicleModels);
        }
    }
}
