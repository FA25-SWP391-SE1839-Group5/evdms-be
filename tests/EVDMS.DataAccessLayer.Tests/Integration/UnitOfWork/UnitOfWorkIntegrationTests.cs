using System;
using System.Threading.Tasks;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EVDMS.DataAccessLayer.Tests.Integration.UnitOfWork
{
    public class UnitOfWorkIntegrationTests
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
        public async Task CompleteAsync_CommitsChanges()
        {
            using var context = GetInMemoryDbContext();
            var unitOfWork = new EVDMS.DataAccessLayer.UnitOfWork.UnitOfWork(context);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "UoW Integration Test",
                Phone = "555-5678",
                Email = "uow@integration.com",
                Address = "456 UoW St",
            };
            await unitOfWork.Customers.AddAsync(customer);
            var changes = await unitOfWork.CompleteAsync();
            Assert.Equal(1, changes);
            var found = await context.Customers.FindAsync(customer.Id);
            Assert.NotNull(found);
        }
    }
}
