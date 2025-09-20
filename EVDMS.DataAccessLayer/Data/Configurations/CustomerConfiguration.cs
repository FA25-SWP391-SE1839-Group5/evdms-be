using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).IsRequired();
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
