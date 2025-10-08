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
        private readonly IStripeService _stripeService;

        public DealerPaymentService(
            IDealerPaymentRepository dealerPaymentRepository,
            IDealerOrderRepository dealerOrderRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IPromotionRepository promotionRepository,
            IStripeService stripeService,
            IMapper mapper
        )
            : base(dealerPaymentRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _promotionRepository = promotionRepository;
            _stripeService = stripeService;
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

            var paymentIntent = await _stripeService.CreatePaymentIntentAsync(finalAmount, "usd");

            var payment = new DealerPayment
            {
                DealerOrderId = dto.DealerOrderId,
                Amount = finalAmount,
                Status = DealerPaymentStatus.Pending,
                PaymentIntentId = paymentIntent.Id,
                CreatedAt = now,
                UpdatedAt = now,
            };

            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<DealerPaymentDto>(payment);
        }

        public async Task MarkAsPaidAsync(string paymentIntentId)
        {
            var payments = await _repository.FindAsync(p => p.PaymentIntentId == paymentIntentId);
            var payment = payments.FirstOrDefault();
            if (payment == null)
                return;
            if (payment.Status == DealerPaymentStatus.Paid)
                return;
            payment.Status = DealerPaymentStatus.Paid;
            payment.UpdatedAt = DateTime.UtcNow;
            _repository.Update(payment);
            await _repository.SaveChangesAsync();
        }

        public async Task MarkAsPendingAsync(string paymentIntentId)
        {
            var payments = await _repository.FindAsync(p => p.PaymentIntentId == paymentIntentId);
            var payment = payments.FirstOrDefault();
            if (payment == null)
                return;
            if (payment.Status == DealerPaymentStatus.Pending)
                return;
            payment.Status = DealerPaymentStatus.Pending;
            payment.UpdatedAt = DateTime.UtcNow;
            _repository.Update(payment);
            await _repository.SaveChangesAsync();
        }

        public async Task MarkAsFailedAsync(string paymentIntentId)
        {
            var payments = await _repository.FindAsync(p => p.PaymentIntentId == paymentIntentId);
            var payment = payments.FirstOrDefault();
            if (payment == null)
                return;
            if (payment.Status == DealerPaymentStatus.Failed)
                return;
            payment.Status = DealerPaymentStatus.Failed;
            payment.UpdatedAt = DateTime.UtcNow;
            _repository.Update(payment);
            await _repository.SaveChangesAsync();
        }
    }
}
