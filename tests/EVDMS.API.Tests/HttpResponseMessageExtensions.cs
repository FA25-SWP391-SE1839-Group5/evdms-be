using System.Net.Http.Json;
using EVDMS.API.Middleware;
using EVDMS.Common.DTOs;

namespace EVDMS.API.Tests
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<PaginatedResult<T>> ReadPagedResultAsync<T>(
            this HttpResponseMessage response
        )
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<PaginatedResult<T>>();
            if (result == null)
            {
                throw new InvalidOperationException(
                    "Response body could not be deserialized into PaginatedResult."
                );
            }
            return result;
        }

        public static async Task<ApiResponse<PaginatedResult<T>>> ReadApiPagedResultAsync<T>(
            this HttpResponseMessage response
        )
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<
                ApiResponse<PaginatedResult<T>>
            >();
            if (result == null)
            {
                throw new InvalidOperationException(
                    "Response body could not be deserialized into ApiResponse<PaginatedResult>."
                );
            }
            return result;
        }
    }
}
