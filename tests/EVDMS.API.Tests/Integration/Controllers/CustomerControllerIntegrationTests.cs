using System.Net;
using System.Net.Http.Json;
using EVDMS.Common.DTOs;

namespace EVDMS.API.Tests.Integration.Controllers
{
    public class CustomerControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public CustomerControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var response = await _client.GetAsync(
                "/api/customers",
                TestContext.Current.CancellationToken
            );
            var result = await response.ReadPagedResultAsync<CustomerDto>();

            Assert.NotNull(result);
            Assert.NotEmpty(result.Items);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Create_And_GetById_Works()
        {
            var createDto = new CreateCustomerDto
            {
                FullName = "Integration Test",
                Phone = "555-0000",
                Email = "integration@evdms.com",
                Address = "123 Integration Lane",
            };

            var post = await _client.PostAsJsonAsync(
                "/api/customers",
                createDto,
                cancellationToken: TestContext.Current.CancellationToken
            );
            post.EnsureSuccessStatusCode();

            var created = await post.Content.ReadFromJsonAsync<CustomerDto>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.NotNull(created);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            get.EnsureSuccessStatusCode();

            var found = await get.Content.ReadFromJsonAsync<CustomerDto>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.Equal(createDto.FullName, found!.FullName);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Update_Works()
        {
            var createDto = new CreateCustomerDto
            {
                FullName = "Before Update",
                Phone = "555-1111",
                Email = "before@evdms.com",
                Address = "111 Before St",
            };

            var post = await _client.PostAsJsonAsync(
                "/api/customers",
                createDto,
                cancellationToken: TestContext.Current.CancellationToken
            );
            var created = await post.Content.ReadFromJsonAsync<CustomerDto>(
                cancellationToken: TestContext.Current.CancellationToken
            );

            var updateDto = new UpdateCustomerDto
            {
                FullName = "After Update",
                Phone = "555-2222",
                Email = "after@evdms.com",
                Address = "222 After St",
            };

            var put = await _client.PutAsJsonAsync(
                $"/api/customers/{created!.Id}",
                updateDto,
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.Equal(HttpStatusCode.NoContent, put.StatusCode);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            var found = await get.Content.ReadFromJsonAsync<CustomerDto>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.Equal("After Update", found!.FullName);
            Assert.Equal("555-2222", found.Phone);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task Delete_Works()
        {
            var createDto = new CreateCustomerDto
            {
                FullName = "To Delete",
                Phone = "555-3333",
                Email = "delete@evdms.com",
                Address = "333 Delete St",
            };

            var post = await _client.PostAsJsonAsync(
                "/api/customers",
                createDto,
                cancellationToken: TestContext.Current.CancellationToken
            );
            var created = await post.Content.ReadFromJsonAsync<CustomerDto>(
                cancellationToken: TestContext.Current.CancellationToken
            );

            var del = await _client.DeleteAsync(
                $"/api/customers/{created!.Id}",
                TestContext.Current.CancellationToken
            );
            Assert.Equal(HttpStatusCode.NoContent, del.StatusCode);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            Assert.Equal(HttpStatusCode.NotFound, get.StatusCode);
        }
    }
}
