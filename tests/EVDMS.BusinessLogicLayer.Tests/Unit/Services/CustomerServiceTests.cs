using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Implementations;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Moq;

namespace EVDMS.BusinessLogicLayer.Tests.Unit.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly CustomerService _service;
        private readonly Mock<ICustomerRepository> _customerRepoMock;

        public CustomerServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _customerRepoMock = new Mock<ICustomerRepository>();
            _service = new CustomerService(_customerRepoMock.Object, _mapperMock.Object);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetByIdAsync_ReturnsMappedDto_WhenCustomerExists()
        {
            var id = Guid.NewGuid();
            var customer = new Customer
            {
                Id = id,
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };
            var dto = new CustomerDto
            {
                Id = id,
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(customer);
            _mapperMock.Setup(m => m.Map<CustomerDto>(customer)).Returns(dto);

            var result = await _service.GetByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(dto.Id, result.Id);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenCustomerDoesNotExist()
        {
            var id = Guid.NewGuid();
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Customer)null);

            var result = await _service.GetByIdAsync(id);

            Assert.Null(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task CreateAsync_AddsCustomerAndReturnsDto()
        {
            var dto = new CreateCustomerDto
            {
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address,
            };
            var mappedDto = new CustomerDto
            {
                Id = customer.Id,
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address,
            };
            _mapperMock.Setup(m => m.Map<Customer>(dto)).Returns(customer);
            _mapperMock.Setup(m => m.Map<CustomerDto>(customer)).Returns(mappedDto);

            var result = await _service.CreateAsync(dto);

            _customerRepoMock.Verify(r => r.AddAsync(customer), Times.Once);
            _customerRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.Equal(mappedDto.Id, result.Id);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task UpdateAsync_UpdatesCustomer_WhenExists()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto
            {
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };
            var customer = new Customer
            {
                Id = id,
                FullName = "Old",
                Phone = "000",
                Email = "old@b.com",
                Address = "OldAddr",
            };
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(customer);

            var result = await _service.UpdateAsync(id, dto);

            _mapperMock.Verify(m => m.Map(dto, customer), Times.Once);
            _customerRepoMock.Verify(r => r.Update(customer), Times.Once);
            _customerRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.True(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task UpdateAsync_ReturnsFalse_WhenCustomerNotFound()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto();
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Customer)null);

            var result = await _service.UpdateAsync(id, dto);

            Assert.False(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task DeleteAsync_RemovesCustomer_WhenExists()
        {
            var id = Guid.NewGuid();
            var customer = new Customer
            {
                Id = id,
                FullName = "Test",
                Phone = "123",
                Email = "a@b.com",
                Address = "Addr",
            };
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(customer);

            var result = await _service.DeleteAsync(id);

            _customerRepoMock.Verify(r => r.Remove(customer), Times.Once);
            _customerRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.True(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task DeleteAsync_ReturnsFalse_WhenCustomerNotFound()
        {
            var id = Guid.NewGuid();
            _customerRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Customer)null);

            var result = await _service.DeleteAsync(id);

            Assert.False(result);
        }
    }
}
