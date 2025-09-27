using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<RoleDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var (roles, totalCount) = await _roleRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder
            );
            return new PaginatedResult<RoleDto>
            {
                Items = _mapper.Map<IEnumerable<RoleDto>>(roles),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<RoleDto?> GetByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role == null ? null : _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync();
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateRoleDto dto)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return false;
            _mapper.Map(dto, role);
            _roleRepository.Update(role);
            await _roleRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchRoleDto dto)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return false;
            _mapper.Map(dto, role);
            _roleRepository.Update(role);
            await _roleRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return false;
            _roleRepository.Remove(role);
            await _roleRepository.SaveChangesAsync();
            return true;
        }
    }
}
