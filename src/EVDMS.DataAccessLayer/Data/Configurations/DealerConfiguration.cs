using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.ConfigureTimestamps();
        }
    }
}
