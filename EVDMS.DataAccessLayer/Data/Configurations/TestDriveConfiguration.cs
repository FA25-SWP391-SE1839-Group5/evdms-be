using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class TestDriveConfiguration : IEntityTypeConfiguration<TestDrive>
    {
        public void Configure(EntityTypeBuilder<TestDrive> builder)
        {
            builder.HasKey(td => td.Id);
            builder.Property(td => td.ScheduledAt).IsRequired();
            builder.Property(td => td.Status).IsRequired();
            builder.HasOne(td => td.Customer)
                .WithMany(c => c.TestDrives)
                .HasForeignKey(td => td.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(td => td.Dealer)
                .WithMany(d => d.TestDrives)
                .HasForeignKey(td => td.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(td => td.Vehicle)
                .WithMany(v => v.TestDrives)
                .HasForeignKey(td => td.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}