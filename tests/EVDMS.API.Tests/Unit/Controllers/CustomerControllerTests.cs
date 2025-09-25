using EVDMS.API.Controllers;
using EVDMS.API.Middleware;
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
            var ok = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<PaginatedResult<CustomerDto>>>(ok.Value);
            Assert.Equal(paged, apiResponse.Data);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetById_ReturnsOk_WhenFound()
        {
            var id = Guid.NewGuid();
            var dto = new CustomerDto { Id = id };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(dto);
            var result = await _controller.GetById(id);
            var ok = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<CustomerDto>>(ok.Value);
            Assert.Equal(dto, apiResponse.Data);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task GetById_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((CustomerDto?)null);
            var result = await _controller.GetById(id);
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(notFound.Value);
            Assert.False(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            var dto = new CreateCustomerDto();
            var created = new CustomerDto { Id = Guid.NewGuid() };
            _serviceMock.Setup(s => s.CreateAsync(dto)).ReturnsAsync(created);
            var result = await _controller.Create(dto);
            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<CustomerDto>>(createdAt.Value);
            Assert.Equal(created, apiResponse.Data);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Update_ReturnsOk_WhenSuccess()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto();
            _serviceMock.Setup(s => s.UpdateAsync(id, dto)).ReturnsAsync(true);
            var result = await _controller.Update(id, dto);
            var ok = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(ok.Value);
            Assert.True(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Update_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            var dto = new UpdateCustomerDto();
            _serviceMock.Setup(s => s.UpdateAsync(id, dto)).ReturnsAsync(false);
            var result = await _controller.Update(id, dto);
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(notFound.Value);
            Assert.False(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Patch_ReturnsOk_WhenSuccess()
        {
            var id = Guid.NewGuid();
            var dto = new PatchCustomerDto();
            _serviceMock.Setup(s => s.PatchAsync(id, dto)).ReturnsAsync(true);
            var result = await _controller.Patch(id, dto);
            var ok = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(ok.Value);
            Assert.True(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Patch_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            var dto = new PatchCustomerDto();
            _serviceMock.Setup(s => s.PatchAsync(id, dto)).ReturnsAsync(false);
            var result = await _controller.Patch(id, dto);
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(notFound.Value);
            Assert.False(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Delete_ReturnsOk_WhenSuccess()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);
            var result = await _controller.Delete(id);
            var ok = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(ok.Value);
            Assert.True(apiResponse.Success);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public async Task Delete_ReturnsNotFound_WhenMissing()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(false);
            var result = await _controller.Delete(id);
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(notFound.Value);
            Assert.False(apiResponse.Success);
        }
    }
}
