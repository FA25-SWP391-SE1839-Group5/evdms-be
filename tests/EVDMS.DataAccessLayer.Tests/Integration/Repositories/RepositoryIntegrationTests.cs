using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Tests.Integration.Repositories
{
    public class RepositoryIntegrationTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task AddAndGetById_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var repo = new Repository<Customer>(context);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "Integration Test",
                Phone = "555-1234",
                Email = "test@integration.com",
                Address = "123 Integration St",
            };
            await repo.AddAsync(customer);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var result = await repo.GetByIdAsync(customer.Id);
            Assert.NotNull(result);
            Assert.Equal(customer.FullName, result.FullName);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Update_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var repo = new Repository<Customer>(context);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "Before Update",
                Phone = "555-1234",
                Email = "test@integration.com",
                Address = "123 Integration St",
            };
            await repo.AddAsync(customer);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            customer.FullName = "After Update";
            repo.Update(customer);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var result = await repo.GetByIdAsync(customer.Id);
            Assert.Equal("After Update", result!.FullName);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Remove_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var repo = new Repository<Customer>(context);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "To Remove",
                Phone = "555-1234",
                Email = "test@integration.com",
                Address = "123 Integration St",
            };
            await repo.AddAsync(customer);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            repo.Remove(customer);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var result = await repo.GetByIdAsync(customer.Id);
            Assert.Null(result);
        }
    }
}
