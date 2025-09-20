using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.DataAccessLayer.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoleName).IsRequired();
            builder.Property(r => r.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(r => r.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
