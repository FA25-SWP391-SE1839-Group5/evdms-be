using EVDMS.Common.DTOs;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IRoleService
    {
        Task<PaginatedResult<RoleDto>> GetAllAsync(int page, int pageSize);
        Task<RoleDto?> GetByIdAsync(Guid id);
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateRoleDto dto);
        Task<bool> PatchAsync(Guid id, PatchRoleDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
