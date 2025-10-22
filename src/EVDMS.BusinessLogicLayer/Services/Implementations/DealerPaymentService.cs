using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerPaymentService
        : BaseService<
            DealerPayment,
            DealerPaymentDto,
            CreateDealerPaymentDto,
            UpdateDealerPaymentDto,
            PatchDealerPaymentDto
        >,
            IDealerPaymentService
    {
        private readonly IDealerOrderRepository _dealerOrderRepository;
        private readonly IVehicleVariantRepository _vehicleVariantRepository;
        private readonly IPromotionRepository _promotionRepository;

        public DealerPaymentService(
            IDealerPaymentRepository dealerPaymentRepository,
            IDealerOrderRepository dealerOrderRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IPromotionRepository promotionRepository,
            IMapper mapper
        )
            : base(dealerPaymentRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _promotionRepository = promotionRepository;
        }

        public override async Task<DealerPaymentDto> CreateAsync(CreateDealerPaymentDto dto)
        {
            var dealerOrder =
                await _dealerOrderRepository.GetByIdAsync(dto.DealerOrderId)
                ?? throw new Exception("DealerOrder not found");

            var variant =
                await _vehicleVariantRepository.GetByIdAsync(dealerOrder.VariantId)
                ?? throw new Exception("VehicleVariant not found");
            var basePrice = variant.BasePrice;
            var quantity = dealerOrder.Quantity;
            var now = DateTime.UtcNow;

            var promotions = await _promotionRepository.FindAsync(p =>
                p.Type == PromotionType.Oem && p.StartDate <= now && p.EndDate >= now
            );

            decimal discountPercent = promotions.Any() ? promotions.Max(p => p.DiscountPercent) : 0;

            var totalPrice = basePrice * quantity;
            var discountAmount = totalPrice * (discountPercent / 100m);
            var finalAmount = totalPrice - discountAmount;

            var payment = new DealerPayment
            {
                DealerOrderId = dto.DealerOrderId,
                Amount = finalAmount,
                Status = DealerPaymentStatus.Pending,
                CreatedAt = now,
                UpdatedAt = now,
            };

            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<DealerPaymentDto>(payment);
        }
    }
}
