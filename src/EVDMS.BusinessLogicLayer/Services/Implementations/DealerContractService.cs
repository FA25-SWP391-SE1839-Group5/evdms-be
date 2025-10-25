using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerContractService
        : BaseService<
            DealerContract,
            DealerContractDto,
            CreateDealerContractDto,
            UpdateDealerContractDto,
            PatchDealerContractDto
        >,
            IDealerContractService
    {
        private readonly IDealerContractRepository _dealerContractRepository;

        public DealerContractService(
            IDealerContractRepository dealerContractRepository,
            IMapper mapper
        )
            : base(dealerContractRepository, mapper)
        {
            _dealerContractRepository = dealerContractRepository;
        }

        public override async Task<DealerContractDto> CreateAsync(CreateDealerContractDto dto)
        {
            // Check for overlapping contracts
            var overlapping = await _dealerContractRepository.FindAsync(c =>
                c.DealerId == dto.DealerId
                && c.StartDate <= dto.EndDate
                && c.EndDate >= dto.StartDate
            );
            if (overlapping.Any())
            {
                throw new InvalidOperationException(
                    "The contract dates overlap with an existing contract for this dealer."
                );
            }
            var entity = _mapper.Map<DealerContract>(dto);
            await _dealerContractRepository.AddAsync(entity);
            await _dealerContractRepository.SaveChangesAsync();
            return _mapper.Map<DealerContractDto>(entity);
        }
    }
}
