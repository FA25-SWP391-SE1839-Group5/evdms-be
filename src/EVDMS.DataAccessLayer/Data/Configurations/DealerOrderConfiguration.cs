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

            builder.Property(d => d.Color).HasConversion<string>();
            builder.Property(d => d.Status).HasConversion<string>();

            builder
                .HasOne(d => d.Dealer)
                .WithMany(dealer => dealer.DealerOrders)
                .HasForeignKey(d => d.DealerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(d => d.VehicleVariant)
                .WithMany(variant => variant.DealerOrders)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasData(DealerOrderSeed.DealerOrders);
        }
    }
}
