using EVDMS.Common.DTOs;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<PaginatedResult<CustomerDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        );
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateCustomerDto dto);
        Task<bool> PatchAsync(Guid id, PatchCustomerDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
