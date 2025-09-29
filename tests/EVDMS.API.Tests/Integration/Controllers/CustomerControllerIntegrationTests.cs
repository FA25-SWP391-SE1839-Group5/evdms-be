using System.Net;
using System.Net.Http.Json;
using EVDMS.API.Middlewares;
using EVDMS.Common.Dtos;

namespace EVDMS.API.Tests.Integration.Controllers
{
    public class CustomerControllerIntegrationTests(CustomWebApplicationFactory factory)
        : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Trait("Category", "Integration")]
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var response = await _client.GetAsync(
                "/api/customers",
                TestContext.Current.CancellationToken
            );
            var apiResponse = await response.Content.ReadFromJsonAsync<
                ApiResponse<PaginatedResult<CustomerDto>>
            >(cancellationToken: TestContext.Current.CancellationToken);
            Assert.NotNull(apiResponse);
            Assert.True(apiResponse.Success);
            Assert.NotNull(apiResponse.Data);
            Assert.NotEmpty(apiResponse.Data.Items);
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

            var postApiResponse = await post.Content.ReadFromJsonAsync<ApiResponse<CustomerDto>>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.NotNull(postApiResponse);
            Assert.True(postApiResponse.Success);
            var created = postApiResponse.Data;
            Assert.NotNull(created);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            get.EnsureSuccessStatusCode();

            var getApiResponse = await get.Content.ReadFromJsonAsync<ApiResponse<CustomerDto>>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            Assert.NotNull(getApiResponse);
            Assert.True(getApiResponse.Success);
            var found = getApiResponse.Data;
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
            var postApiResponse = await post.Content.ReadFromJsonAsync<ApiResponse<CustomerDto>>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            var created = postApiResponse!.Data;

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
            Assert.Equal(HttpStatusCode.OK, put.StatusCode);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            var getApiResponse = await get.Content.ReadFromJsonAsync<ApiResponse<CustomerDto>>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            var found = getApiResponse!.Data;
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
            var postApiResponse = await post.Content.ReadFromJsonAsync<ApiResponse<CustomerDto>>(
                cancellationToken: TestContext.Current.CancellationToken
            );
            var created = postApiResponse!.Data;

            var del = await _client.DeleteAsync(
                $"/api/customers/{created!.Id}",
                TestContext.Current.CancellationToken
            );
            Assert.Equal(HttpStatusCode.OK, del.StatusCode);

            var get = await _client.GetAsync(
                $"/api/customers/{created.Id}",
                TestContext.Current.CancellationToken
            );
            Assert.Equal(HttpStatusCode.NotFound, get.StatusCode);
        }
    }
}
