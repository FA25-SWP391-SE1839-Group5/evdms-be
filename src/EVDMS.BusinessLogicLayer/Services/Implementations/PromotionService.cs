using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class PromotionService
        : BaseService<
            Promotion,
            PromotionDto,
            CreatePromotionDto,
            UpdatePromotionDto,
            PatchPromotionDto
        >,
            IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IDealerRepository _dealerRepository;

        public PromotionService(
            IPromotionRepository promotionRepository,
            IDealerRepository dealerRepository,
            IMapper mapper
        )
            : base(promotionRepository, mapper)
        {
            _promotionRepository = promotionRepository;
            _dealerRepository = dealerRepository;
        }

        public async Task<PromotionDto> CreateAsync(CreatePromotionDto dto, UserRole userRole)
        {
            // Role-based creation
            if (dto.Type == PromotionType.Oem && userRole != UserRole.EvmStaff)
                throw new UnauthorizedAccessException("Only EvmStaff can create Oem promotions.");
            if (dto.Type == PromotionType.Dealer && userRole != UserRole.DealerManager)
                throw new UnauthorizedAccessException(
                    "Only DealerManager can create Dealer promotions."
                );

            // DealerId/Type logic
            if (dto.DealerId.HasValue && dto.Type != PromotionType.Dealer)
                throw new InvalidOperationException("If DealerId is present, Type must be Dealer.");
            if (!dto.DealerId.HasValue && dto.Type != PromotionType.Oem)
                throw new InvalidOperationException("If DealerId is null, Type must be Oem.");

            if (dto.DealerId.HasValue)
            {
                var dealer =
                    await _dealerRepository.GetByIdAsync(dto.DealerId.Value)
                    ?? throw new InvalidOperationException("Dealer not found.");
            }

            // Date logic
            if (dto.EndDate < dto.StartDate)
                throw new InvalidOperationException("EndDate must be after StartDate.");

            var overlapping = await _promotionRepository.FindAsync(p =>
                p.Type == dto.Type
                && (dto.Type != PromotionType.Dealer || p.DealerId == dto.DealerId)
                && dto.StartDate <= p.EndDate
                && dto.EndDate >= p.StartDate
            );
            if (overlapping.Any())
                throw new InvalidOperationException(
                    "Promotion date range conflicts with an existing promotion of the same type."
                );

            var entity = _mapper.Map<Promotion>(dto);
            await _promotionRepository.AddAsync(entity);
            await _promotionRepository.SaveChangesAsync();
            return _mapper.Map<PromotionDto>(entity);
        }
    }
}
