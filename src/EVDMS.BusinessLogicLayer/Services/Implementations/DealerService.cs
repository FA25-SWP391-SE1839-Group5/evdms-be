using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IMapper _mapper;

        public DealerService(IDealerRepository dealerRepository, IMapper mapper)
        {
            _dealerRepository = dealerRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<DealerDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var (dealers, totalCount) = await _dealerRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder
            );
            return new PaginatedResult<DealerDto>
            {
                Items = _mapper.Map<IEnumerable<DealerDto>>(dealers),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<DealerDto?> GetByIdAsync(Guid id)
        {
            var dealer = await _dealerRepository.GetByIdAsync(id);
            return dealer == null ? null : _mapper.Map<DealerDto>(dealer);
        }

        public async Task<DealerDto> CreateAsync(CreateDealerDto dto)
        {
            var dealer = _mapper.Map<Dealer>(dto);
            await _dealerRepository.AddAsync(dealer);
            await _dealerRepository.SaveChangesAsync();
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateDealerDto dto)
        {
            var dealer = await _dealerRepository.GetByIdAsync(id);
            if (dealer == null)
                return false;
            _mapper.Map(dto, dealer);
            _dealerRepository.Update(dealer);
            await _dealerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchDealerDto dto)
        {
            var dealer = await _dealerRepository.GetByIdAsync(id);
            if (dealer == null)
                return false;
            _mapper.Map(dto, dealer);
            _dealerRepository.Update(dealer);
            await _dealerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var dealer = await _dealerRepository.GetByIdAsync(id);
            if (dealer == null)
                return false;
            _dealerRepository.Remove(dealer);
            await _dealerRepository.SaveChangesAsync();
            return true;
        }
    }
}
