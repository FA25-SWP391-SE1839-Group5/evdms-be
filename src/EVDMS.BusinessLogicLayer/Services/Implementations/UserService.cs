using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<UserDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var (users, totalCount) = await _userRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder
            );
            return new PaginatedResult<UserDto>
            {
                Items = _mapper.Map<IEnumerable<UserDto>>(users),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _mapper.Map(dto, user);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _mapper.Map(dto, user);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
