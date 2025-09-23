using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerOrderConfiguration : IEntityTypeConfiguration<DealerOrder>
    {
        public void Configure(EntityTypeBuilder<DealerOrder> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(dealerOrder => dealerOrder.Dealer)
                .WithMany(dealerOrder => dealerOrder.DealerOrders)
                .HasForeignKey(dealerOrder => dealerOrder.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
