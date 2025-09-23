using EVDMS.API.Controllers;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EVDMS.API.Tests.Unit.Controllers
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _serviceMock;
        private readonly CustomerController _controller;

        public CustomerControllerTests()
        {
            _serviceMock = new Mock<ICustomerService>();
            _controller = new CustomerController(_serviceMock.Object);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetAll_ReturnsOkWithResult()
        {
            var paged = new PaginatedResult<CustomerDto>
            {
                Items = new List<CustomerDto>(),
                TotalResults = 0,
                Page = 1,
                PageSize = 10,
            };
            _serviceMock.Setup(s => s.GetAllAsync(1, 10)).ReturnsAsync(paged);
            var result = await _controller.GetAll(1, 10);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(paged, ok.Value);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetById_ReturnsOk_WhenFound()
        {
            var id = Guid.NewGuid();
            var dto = new CustomerDto { Id = id };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(dto);
            var result = await _controller.GetById(id);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(dto, ok.Value);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetById_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((CustomerDto?)null);
            var result = await _controller.GetById(id);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            var dto = new CreateCustomerDto();
            var created = new CustomerDto { Id = Guid.NewGuid() };
            _serviceMock.Setup(s => s.CreateAsync(dto)).ReturnsAsync(created);
            var result = await _controller.Create(dto);
            var createdAt = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(created, createdAt.Value);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Update_ReturnsNoContent_WhenSuccess()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto();
            _serviceMock.Setup(s => s.UpdateAsync(id, dto)).ReturnsAsync(true);
            var result = await _controller.Update(id, dto);
            Assert.IsType<NoContentResult>(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Update_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto();
            _serviceMock.Setup(s => s.UpdateAsync(id, dto)).ReturnsAsync(false);
            var result = await _controller.Update(id, dto);
            Assert.IsType<NotFoundResult>(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Patch_ReturnsNoContent_WhenSuccess()
        {
            var id = Guid.NewGuid();
            var dto = new PatchCustomerDto();
            _serviceMock.Setup(s => s.PatchAsync(id, dto)).ReturnsAsync(true);
            var result = await _controller.Patch(id, dto);
            Assert.IsType<NoContentResult>(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Patch_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            var dto = new PatchCustomerDto();
            _serviceMock.Setup(s => s.PatchAsync(id, dto)).ReturnsAsync(false);
            var result = await _controller.Patch(id, dto);
            Assert.IsType<NotFoundResult>(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Delete_ReturnsNoContent_WhenSuccess()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);
            var result = await _controller.Delete(id);
            Assert.IsType<NoContentResult>(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Delete_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(false);
            var result = await _controller.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
