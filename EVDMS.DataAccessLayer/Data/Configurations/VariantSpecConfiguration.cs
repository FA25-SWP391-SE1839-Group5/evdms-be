using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class VariantSpecConfiguration : IEntityTypeConfiguration<VariantSpec>
    {
        public void Configure(EntityTypeBuilder<VariantSpec> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(vs => vs.VehicleVariant)
                .WithMany(vv => vv.VariantSpecs)
                .HasForeignKey(vs => vs.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(vs => vs.Spec)
                .WithMany(s => s.VariantSpecs)
                .HasForeignKey(vs => vs.SpecId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(VariantSpecSeed.VariantSpecs);
        }
    }
}
