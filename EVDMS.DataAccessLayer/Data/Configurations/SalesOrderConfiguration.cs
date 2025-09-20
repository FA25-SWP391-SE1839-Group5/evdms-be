using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(so => so.Id);
            builder.Property(so => so.Status).IsRequired();
            builder.Property(so => so.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(so => so.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(so => so.Quotation)
                .WithMany(q => q.SalesOrders)
                .HasForeignKey(so => so.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(so => so.Dealer)
                .WithMany(d => d.SalesOrders)
                .HasForeignKey(so => so.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(so => so.User)
                .WithMany(u => u.SalesOrders)
                .HasForeignKey(so => so.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(so => so.Customer)
                .WithMany(c => c.SalesOrders)
                .HasForeignKey(so => so.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(so => so.Vehicle)
                .WithMany(v => v.SalesOrders)
                .HasForeignKey(so => so.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
