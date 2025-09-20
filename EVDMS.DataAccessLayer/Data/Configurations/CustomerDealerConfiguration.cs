using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class CustomerDealerConfiguration : IEntityTypeConfiguration<CustomerDealer>
    {
        public void Configure(EntityTypeBuilder<CustomerDealer> builder)
        {
            builder.HasKey(cd => cd.Id);
            builder
                .HasOne(cd => cd.Customer)
                .WithMany(c => c.CustomerDealers)
                .HasForeignKey(cd => cd.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(cd => cd.Dealer)
                .WithMany(d => d.CustomerDealers)
                .HasForeignKey(cd => cd.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(cd => cd.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(cd => cd.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
