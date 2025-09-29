using EVDMS.DataAccessLayer.Data.Seeds;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureTimestamps();
            builder.Property(u => u.Role).HasConversion<string>();
            builder.Property(u => u.IsActive).HasDefaultValue(true);
            builder
                .HasOne(u => u.Dealer)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(UserSeed.GetUsers());
        }
    }
}
