using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(p => p.Dealer)
                .WithMany(d => d.Promotions)
                .HasForeignKey(p => p.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
