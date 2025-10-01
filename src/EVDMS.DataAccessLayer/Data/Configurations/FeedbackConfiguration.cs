using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ConfigureTimestamps();
            builder.Property(f => f.Status).HasConversion<string>();
            builder
                .HasOne(f => f.Customer)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(f => f.Dealer)
                .WithMany(d => d.Feedbacks)
                .HasForeignKey(f => f.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(FeedbackSeed.Feedbacks);
        }
    }
}
