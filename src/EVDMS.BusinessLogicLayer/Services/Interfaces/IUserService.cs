using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
        : IBaseService<UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>
    {
        Task<UserDto> CreateAsync(CreateUserDto dto, UserRole currentUserRole);
    }
}
