using EVDMS.DataAccessLayer.Data.Configurations;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDealer> CustomerDealers { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<DealerAllocation> DealerAllocations { get; set; }
        public DbSet<DealerContract> DealerContracts { get; set; }
        public DbSet<DealerOrder> DealerOrders { get; set; }
        public DbSet<DealerOrderItem> DealerOrderItems { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureCategory> FeatureCategories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<OemInventory> OemInventories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesContract> SalesContracts { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<SpecCategory> SpecCategories { get; set; }
        public DbSet<TestDrive> TestDrives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VariantFeature> VariantFeatures { get; set; }
        public DbSet<VariantSpec> VariantSpecs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleVariant> VehicleVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDealerConfiguration());
            modelBuilder.ApplyConfiguration(new DealerAllocationConfiguration());
            modelBuilder.ApplyConfiguration(new DealerConfiguration());
            modelBuilder.ApplyConfiguration(new DealerContractConfiguration());
            modelBuilder.ApplyConfiguration(new DealerOrderConfiguration());
            modelBuilder.ApplyConfiguration(new DealerOrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new OemInventoryConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new QuotationConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SalesContractConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
            modelBuilder.ApplyConfiguration(new SpecCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SpecConfiguration());
            modelBuilder.ApplyConfiguration(new TestDriveConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VariantFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new VariantSpecConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleColorConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleVariantConfiguration());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var now = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var now = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
