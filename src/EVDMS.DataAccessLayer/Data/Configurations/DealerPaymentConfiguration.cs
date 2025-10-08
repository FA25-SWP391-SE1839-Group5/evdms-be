using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerPaymentConfiguration : IEntityTypeConfiguration<DealerPayment>
    {
        public void Configure(EntityTypeBuilder<DealerPayment> builder)
        {
            builder.ConfigureTimestamps();

            builder.Property(dp => dp.Status).HasConversion<string>();

            builder
                .HasOne(dp => dp.DealerOrder)
                .WithMany(dp => dp.DealerPayments)
                .HasForeignKey(dp => dp.DealerOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DealerPaymentSeed.DealerPayments);
        }
    }
}
