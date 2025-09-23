using System.Net.Http.Json;
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
    }
}
