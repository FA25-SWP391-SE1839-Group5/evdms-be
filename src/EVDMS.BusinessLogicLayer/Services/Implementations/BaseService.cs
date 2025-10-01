using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class BaseService<TEntity, TDto, TCreateDto, TUpdateDto, TPatchDto>
        : IBaseService<TDto, TCreateDto, TUpdateDto, TPatchDto>
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<PaginatedResult<TDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var (entities, totalCount) = await _repository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filters,
                allowedColumns
            );
            return new PaginatedResult<TDto>
            {
                Items = _mapper.Map<IEnumerable<TDto>>(entities),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public virtual async Task<TDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? default : _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<bool> UpdateAsync(Guid id, TUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> PatchAsync(Guid id, TPatchDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
