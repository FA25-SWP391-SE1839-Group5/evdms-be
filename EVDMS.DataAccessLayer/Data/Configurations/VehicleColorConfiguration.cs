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
            builder.HasKey(vc => vc.Id);
            builder.Property(vc => vc.ColorName).IsRequired();
            builder.Property(vc => vc.HexCode).IsRequired();
            builder.Property(vc => vc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(vc => vc.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasData(VehicleColorSeed.VehicleColors);
        }
    }
}
