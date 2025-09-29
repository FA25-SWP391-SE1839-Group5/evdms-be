using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerContractService : IDealerContractService
    {
        private readonly IDealerContractRepository _dealerContractRepository;
        private readonly IMapper _mapper;

        public DealerContractService(
            IDealerContractRepository dealerContractRepository,
            IMapper mapper
        )
        {
            _dealerContractRepository = dealerContractRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<DealerContractDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var (contracts, totalCount) = await _dealerContractRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder
            );
            return new PaginatedResult<DealerContractDto>
            {
                Items = _mapper.Map<IEnumerable<DealerContractDto>>(contracts),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<DealerContractDto?> GetByIdAsync(Guid id)
        {
            var contract = await _dealerContractRepository.GetByIdAsync(id);
            return contract == null ? null : _mapper.Map<DealerContractDto>(contract);
        }

        public async Task<DealerContractDto> CreateAsync(CreateDealerContractDto dto)
        {
            var contract = _mapper.Map<DealerContract>(dto);
            await _dealerContractRepository.AddAsync(contract);
            await _dealerContractRepository.SaveChangesAsync();
            return _mapper.Map<DealerContractDto>(contract);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateDealerContractDto dto)
        {
            var contract = await _dealerContractRepository.GetByIdAsync(id);
            if (contract == null)
                return false;
            _mapper.Map(dto, contract);
            _dealerContractRepository.Update(contract);
            await _dealerContractRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchDealerContractDto dto)
        {
            var contract = await _dealerContractRepository.GetByIdAsync(id);
            if (contract == null)
                return false;
            _mapper.Map(dto, contract);
            _dealerContractRepository.Update(contract);
            await _dealerContractRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var contract = await _dealerContractRepository.GetByIdAsync(id);
            if (contract == null)
                return false;
            _dealerContractRepository.Remove(contract);
            await _dealerContractRepository.SaveChangesAsync();
            return true;
        }
    }
}
