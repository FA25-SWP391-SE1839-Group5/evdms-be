using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerContractConfiguration : IEntityTypeConfiguration<DealerContract>
    {
        public void Configure(EntityTypeBuilder<DealerContract> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.Property(dc => dc.StartDate).IsRequired();
            builder.Property(dc => dc.EndDate).IsRequired();
            builder.Property(dc => dc.SalesTarget).IsRequired();
            builder.Property(dc => dc.OutstandingDebt).IsRequired();
            builder.Property(dc => dc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(dc => dc.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(dc => dc.Dealer)
                .WithMany(d => d.DealerContracts)
                .HasForeignKey(dc => dc.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
