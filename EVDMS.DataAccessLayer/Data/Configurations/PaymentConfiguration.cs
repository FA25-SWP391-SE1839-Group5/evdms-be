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
            builder
                .HasOne(p => p.SalesContract)
                .WithMany(sc => sc.Payments)
                .HasForeignKey(p => p.SalesContractId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
