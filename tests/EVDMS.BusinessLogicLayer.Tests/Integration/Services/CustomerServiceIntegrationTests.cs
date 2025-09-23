using System;
using System.Threading.Tasks;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Implementations;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Implementations;
using EVDMS.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;

namespace EVDMS.BusinessLogicLayer.Tests.Integration.Services
{
    public class CustomerServiceIntegrationTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        private IMapper GetMapper()
        {
            var loggerFactory = LoggerFactory.Create(builder => { });
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new Mapping.CustomerProfile());
                },
                loggerFactory
            );
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task CreateAndGetById_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var unitOfWork = new UnitOfWork(context);
            var mapper = GetMapper();
            var service = new CustomerService(unitOfWork, mapper);
            var createDto = new CreateCustomerDto
            {
                FullName = "Integration Test",
                Phone = "555-1234",
                Email = "test@integration.com",
                Address = "123 Integration St",
            };
            var created = await service.CreateAsync(createDto);
            var found = await service.GetByIdAsync(created.Id);
            Assert.NotNull(found);
            Assert.Equal(createDto.FullName, found.FullName);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Update_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var unitOfWork = new UnitOfWork(context);
            var mapper = GetMapper();
            var service = new CustomerService(unitOfWork, mapper);
            var createDto = new CreateCustomerDto
            {
                FullName = "Before Update",
                Phone = "555-1234",
                Email = "test@integration.com",
                Address = "123 Integration St",
            };
            var created = await service.CreateAsync(createDto);
            var updateDto = new UpdateCustomerDto
            {
                FullName = "After Update",
                Phone = "555-5678",
                Email = "after@integration.com",
                Address = "456 Updated St",
            };
            var updated = await service.UpdateAsync(created.Id, updateDto);
            var found = await service.GetByIdAsync(created.Id);
            Assert.True(updated);
            Assert.Equal("After Update", found.FullName);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Delete_WorksCorrectly()
        {
            using var context = GetInMemoryDbContext();
            var unitOfWork = new UnitOfWork(context);
            var mapper = GetMapper();
            var service = new CustomerService(unitOfWork, mapper);
            var createDto = new CreateCustomerDto
            {
                FullName = "To Delete",
                Phone = "555-1234",
                Email = "delete@integration.com",
                Address = "789 Delete St",
            };
            var created = await service.CreateAsync(createDto);
            var deleted = await service.DeleteAsync(created.Id);
            var found = await service.GetByIdAsync(created.Id);
            Assert.True(deleted);
            Assert.Null(found);
        }
    }
}
