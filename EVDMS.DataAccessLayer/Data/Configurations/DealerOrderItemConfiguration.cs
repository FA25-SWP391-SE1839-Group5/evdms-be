using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerOrderItemConfiguration : IEntityTypeConfiguration<DealerOrderItem>
    {
        public void Configure(EntityTypeBuilder<DealerOrderItem> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(item => item.DealerOrder)
                .WithMany(order => order.DealerOrderItems)
                .HasForeignKey(item => item.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(item => item.VehicleVariant)
                .WithMany(variant => variant.DealerOrderItems)
                .HasForeignKey(item => item.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(item => item.VehicleColor)
                .WithMany(color => color.DealerOrderItems)
                .HasForeignKey(item => item.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
