using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IBaseService<TDto, TCreateDto, TUpdateDto, TPatchDto>
    {
        Task<PaginatedResult<TDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        );
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto dto);
        Task<bool> UpdateAsync(Guid id, TUpdateDto dto);
        Task<bool> PatchAsync(Guid id, TPatchDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
