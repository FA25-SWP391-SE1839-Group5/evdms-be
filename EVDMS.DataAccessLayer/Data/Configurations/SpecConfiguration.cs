using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SpecConfiguration : IEntityTypeConfiguration<Spec>
    {
        public void Configure(EntityTypeBuilder<Spec> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SpecName).IsRequired();
            builder.Property(s => s.Unit).IsRequired();
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(s => s.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
