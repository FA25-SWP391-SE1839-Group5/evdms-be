using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerService
    {
        Task<PaginatedResult<DealerDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        );
        Task<DealerDto?> GetByIdAsync(Guid id);
        Task<DealerDto> CreateAsync(CreateDealerDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateDealerDto dto);
        Task<bool> PatchAsync(Guid id, PatchDealerDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
