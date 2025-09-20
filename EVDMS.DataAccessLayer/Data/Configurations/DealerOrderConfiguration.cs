using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerOrderConfiguration : IEntityTypeConfiguration<DealerOrder>
    {
        public void Configure(EntityTypeBuilder<DealerOrder> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Status).IsRequired();
            builder.HasOne(order => order.Dealer)
                .WithMany(dealer => dealer.DealerOrders)
                .HasForeignKey(order => order.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}