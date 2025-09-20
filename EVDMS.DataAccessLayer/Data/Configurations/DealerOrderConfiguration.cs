using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerOrderConfiguration : IEntityTypeConfiguration<DealerOrder>
    {
        public void Configure(EntityTypeBuilder<DealerOrder> builder)
        {
            builder.HasKey(dealerOrder => dealerOrder.Id);
            builder.Property(dealerOrder => dealerOrder.Status).IsRequired();
            builder.Property(dealerOrder => dealerOrder.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(dealerOrder => dealerOrder.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(dealerOrder => dealerOrder.Dealer)
                .WithMany(dealerOrder => dealerOrder.DealerOrders)
                .HasForeignKey(dealerOrder => dealerOrder.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
