using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EVDMS.DataAccessLayer.Tests.Unit.Repositories
{
    public class RepositoryTests
    {
        [Trait("Category", "Unit")]
        [Fact]
        public async Task AddAsync_AddsEntityToDbSet()
        {
            var mockSet = new Mock<DbSet<Customer>>();
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            mockContext.Setup(m => m.Set<Customer>()).Returns(mockSet.Object);
            var repo = new Repository<Customer>(mockContext.Object);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };

            await repo.AddAsync(customer);

            mockSet.Verify(m => m.AddAsync(customer, default), Times.Once);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Update_UpdatesEntityInDbSet()
        {
            var mockSet = new Mock<DbSet<Customer>>();
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            mockContext.Setup(m => m.Set<Customer>()).Returns(mockSet.Object);
            var repo = new Repository<Customer>(mockContext.Object);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };

            repo.Update(customer);

            mockSet.Verify(m => m.Update(customer), Times.Once);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Remove_RemovesEntityFromDbSet()
        {
            var mockSet = new Mock<DbSet<Customer>>();
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            mockContext.Setup(m => m.Set<Customer>()).Returns(mockSet.Object);
            var repo = new Repository<Customer>(mockContext.Object);
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };

            repo.Remove(customer);

            mockSet.Verify(m => m.Remove(customer), Times.Once);
        }
    }
}
