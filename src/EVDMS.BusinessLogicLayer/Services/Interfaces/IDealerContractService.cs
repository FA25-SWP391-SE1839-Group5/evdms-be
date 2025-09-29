using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerContractService
    {
        Task<PaginatedResult<DealerContractDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        );
        Task<DealerContractDto?> GetByIdAsync(Guid id);
        Task<DealerContractDto> CreateAsync(CreateDealerContractDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateDealerContractDto dto);
        Task<bool> PatchAsync(Guid id, PatchDealerContractDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
