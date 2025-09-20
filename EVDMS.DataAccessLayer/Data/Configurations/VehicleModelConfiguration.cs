using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(vm => vm.Id);
            builder.Property(vm => vm.ModelName).IsRequired();
            builder.Property(vm => vm.Description).IsRequired();
            builder.Property(vm => vm.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(vm => vm.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
