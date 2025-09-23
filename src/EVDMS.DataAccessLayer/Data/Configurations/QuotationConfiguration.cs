using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class QuotationConfiguration : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(q => q.Dealer)
                .WithMany(d => d.Quotations)
                .HasForeignKey(q => q.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(q => q.User)
                .WithMany(u => u.Quotations)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(q => q.Customer)
                .WithMany(c => c.Quotations)
                .HasForeignKey(q => q.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
