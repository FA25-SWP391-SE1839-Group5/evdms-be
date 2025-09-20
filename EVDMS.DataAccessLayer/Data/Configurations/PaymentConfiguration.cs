using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();
            builder.Property(p => p.Method).IsRequired();
            builder.HasOne(p => p.SalesContract)
                .WithMany(sc => sc.Payments)
                .HasForeignKey(p => p.SalesContractId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}