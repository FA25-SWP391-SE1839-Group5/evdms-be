using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class SalesContractConfiguration : IEntityTypeConfiguration<SalesContract>
    {
        public void Configure(EntityTypeBuilder<SalesContract> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(sc => sc.SalesOrder)
                .WithMany(so => so.SalesContracts)
                .HasForeignKey(sc => sc.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
