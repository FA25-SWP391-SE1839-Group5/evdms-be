using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SalesContractConfiguration : IEntityTypeConfiguration<SalesContract>
    {
        public void Configure(EntityTypeBuilder<SalesContract> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.ContractDate).IsRequired();
            builder.Property(sc => sc.TotalAmount).IsRequired();
            builder.Property(sc => sc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(sc => sc.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder
                .HasOne(sc => sc.SalesOrder)
                .WithMany(so => so.SalesContracts)
                .HasForeignKey(sc => sc.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
