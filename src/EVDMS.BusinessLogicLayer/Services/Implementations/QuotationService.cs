using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class QuotationService
        : BaseService<
            Quotation,
            QuotationDto,
            CreateQuotationDto,
            UpdateQuotationDto,
            PatchQuotationDto
        >,
            IQuotationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleVariantRepository _vehicleVariantRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IAuditLogService _auditLogService;
        private static DateTime Now => DateTime.UtcNow;

        public QuotationService(
            IQuotationRepository quotationRepository,
            ICustomerRepository customerRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IPromotionRepository promotionRepository,
            IMapper mapper,
            IAuditLogService auditLogService
        )
            : base(quotationRepository, mapper)
        {
            _customerRepository = customerRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _promotionRepository = promotionRepository;
            _auditLogService = auditLogService;
        }

        public async Task<QuotationDto> CreateAsync(
            CreateQuotationDto dto,
            Guid dealerId,
            Guid userId
        )
        {
            _ =
                await _customerRepository.GetByIdAsync(dto.CustomerId)
                ?? throw new KeyNotFoundException(
                    $"Customer with ID {dto.CustomerId} does not exist."
                );

            var variant =
                await _vehicleVariantRepository.GetByIdAsync(dto.VariantId)
                ?? throw new KeyNotFoundException(
                    $"VehicleVariant with ID {dto.VariantId} does not exist."
                );
            var basePrice = variant.BasePrice;

            var promotions = await _promotionRepository.FindAsync(p =>
                p.Type == PromotionType.Dealer
                && p.DealerId == dealerId
                && p.StartDate <= Now
                && p.EndDate >= Now
            );
            decimal discountPercent = promotions.Any() ? promotions.Max(p => p.DiscountPercent) : 0;
            decimal discountAmount = basePrice * (discountPercent / 100m);
            decimal totalAmount = basePrice - discountAmount;

            var quotation = _mapper.Map<Quotation>(dto);
            quotation.DealerId = dealerId;
            quotation.UserId = userId;
            quotation.TotalAmount = totalAmount;
            quotation.Status = QuotationStatus.Draft;

            await _repository.AddAsync(quotation);
            await _repository.SaveChangesAsync();

            // Log CreateQuotation event
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = userId,
                    Action = AuditLogAction.CreateQuotation,
                    Description = $"Quotation {quotation.Id} created by user {userId}.",
                }
            );

            return _mapper.Map<QuotationDto>(quotation);
        }
    }
}
