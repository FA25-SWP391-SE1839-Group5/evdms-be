using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
        : IBaseService<UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>
    {
        Task<UserDto> CreateAsync(CreateUserDto dto, UserRole currentUserRole);
        Task<UserDto?> GetCurrentUserAsync(Guid userId);
        Task<CsvExportResult> ExportToCsvAsync();
        Task<CsvExportResult> ExportByDealerToCsvAsync(Guid dealerId);
    }
}
