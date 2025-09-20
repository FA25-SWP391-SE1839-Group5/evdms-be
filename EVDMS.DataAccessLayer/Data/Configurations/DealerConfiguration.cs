using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.DealerName).IsRequired();
            builder.Property(d => d.Region).IsRequired();
            builder.Property(d => d.Address).IsRequired();
            builder.Property(d => d.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(d => d.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
