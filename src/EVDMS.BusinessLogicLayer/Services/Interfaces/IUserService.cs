using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<PaginatedResult<UserDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        );
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto, UserRole currentUserRole);
        Task<bool> UpdateAsync(Guid id, UpdateUserDto dto);
        Task<bool> PatchAsync(Guid id, PatchUserDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
