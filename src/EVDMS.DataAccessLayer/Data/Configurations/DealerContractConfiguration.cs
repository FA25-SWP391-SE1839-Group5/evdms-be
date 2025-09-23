using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerContractConfiguration : IEntityTypeConfiguration<DealerContract>
    {
        public void Configure(EntityTypeBuilder<DealerContract> builder)
        {
            builder.ConfigureTimestamps();
            builder
                .HasOne(dc => dc.Dealer)
                .WithMany(d => d.DealerContracts)
                .HasForeignKey(dc => dc.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
