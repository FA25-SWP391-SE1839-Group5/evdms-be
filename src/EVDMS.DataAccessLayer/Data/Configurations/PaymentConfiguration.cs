using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ConfigureTimestamps();
            builder.Property(u => u.Method).HasConversion<string>();
            builder
                .HasOne(p => p.SalesOrder)
                .WithMany(so => so.Payments)
                .HasForeignKey(p => p.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(PaymentSeed.Payments);
        }
    }
}
