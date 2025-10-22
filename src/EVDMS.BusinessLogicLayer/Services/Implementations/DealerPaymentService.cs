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
        private readonly IOemInventoryRepository _oemInventoryRepository;
        private readonly IDealerContractRepository _dealerContractRepository;

        private static DateTime Now => DateTime.UtcNow;

        public DealerPaymentService(
            IDealerPaymentRepository dealerPaymentRepository,
            IDealerOrderRepository dealerOrderRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IPromotionRepository promotionRepository,
            IOemInventoryRepository oemInventoryRepository,
            IDealerContractRepository dealerContractRepository,
            IMapper mapper
        )
            : base(dealerPaymentRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _promotionRepository = promotionRepository;
            _oemInventoryRepository = oemInventoryRepository;
            _dealerContractRepository = dealerContractRepository;
        }

        public override async Task<DealerPaymentDto> CreateAsync(CreateDealerPaymentDto dto)
        {
            var dealerOrder =
                await _dealerOrderRepository.GetByIdAsync(dto.DealerOrderId)
                ?? throw new KeyNotFoundException(
                    $"DealerOrder with ID {dto.DealerOrderId} does not exist."
                );

            var variant =
                await _vehicleVariantRepository.GetByIdAsync(dealerOrder.VariantId)
                ?? throw new KeyNotFoundException(
                    $"VehicleVariant with ID {dealerOrder.VariantId} does not exist."
                );

            dealerOrder.Status = DealerOrderStatus.Confirmed;
            _dealerOrderRepository.Update(dealerOrder);

            var basePrice = variant.BasePrice;
            var quantity = dealerOrder.Quantity;

            // Apply OEM promotions
            var promotions = await _promotionRepository.FindAsync(p =>
                p.Type == PromotionType.Oem && p.StartDate <= Now && p.EndDate >= Now
            );

            decimal discountPercent = promotions.Any() ? promotions.Max(p => p.DiscountPercent) : 0;

            var totalPrice = basePrice * quantity;
            var discountAmount = totalPrice * (discountPercent / 100m);
            var finalAmount = totalPrice - discountAmount;

            // Reduce OEM inventory
            var oemInventory =
                (
                    await _oemInventoryRepository.FindAsync(i => i.VariantId == variant.Id)
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"OEM Inventory for Variant ID {variant.Id} does not exist."
                );
            if (oemInventory.Quantity < quantity)
                throw new InvalidOperationException("Not enough inventory for this variant.");
            oemInventory.Quantity -= quantity;
            oemInventory.UpdatedAt = Now;
            _oemInventoryRepository.Update(oemInventory);

            // Increase dealer's outstanding debt
            var contract =
                (
                    await _dealerContractRepository.FindAsync(c =>
                        c.DealerId == dealerOrder.DealerId && c.StartDate <= Now && c.EndDate >= Now
                    )
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"No active contracts found for dealer with ID: {dealerOrder.DealerId}."
                );
            contract.OutstandingDebt += finalAmount;
            contract.UpdatedAt = Now;
            _dealerContractRepository.Update(contract);

            var payment = _mapper.Map<DealerPayment>(dto);
            payment.Amount = finalAmount;
            payment.Status = DealerPaymentStatus.Pending;

            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<DealerPaymentDto>(payment);
        }

        public async Task MarkPaymentPaidAsync(Guid paymentId)
        {
            // Update DealerPayment status to Paid
            var payment =
                await _repository.GetByIdAsync(paymentId)
                ?? throw new KeyNotFoundException(
                    $"DealerPayment with ID {paymentId} does not exist."
                );
            if (payment.Status != DealerPaymentStatus.Pending)
                throw new InvalidOperationException("DealerPayment's Status is not Pending.");
            payment.Status = DealerPaymentStatus.Paid;
            _repository.Update(payment);
            await _repository.SaveChangesAsync();

            // Reduce dealer's outstanding debt on the active contract only
            var dealerOrder =
                await _dealerOrderRepository.GetByIdAsync(payment.DealerOrderId)
                ?? throw new KeyNotFoundException(
                    $"DealerOrder with ID {payment.DealerOrderId} does not exist."
                );
            var contract =
                (
                    await _dealerContractRepository.FindAsync(c =>
                        c.DealerId == dealerOrder.DealerId && c.StartDate <= Now && c.EndDate >= Now
                    )
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"No active contracts found for dealer with ID: {dealerOrder.DealerId}."
                );
            contract.OutstandingDebt -= payment.Amount;
            _dealerContractRepository.Update(contract);
            await _dealerContractRepository.SaveChangesAsync();
        }

        public async Task MarkPaymentFailedAsync(Guid paymentId)
        {
            // Update DealerPayment status to Failed
            var payment =
                await _repository.GetByIdAsync(paymentId)
                ?? throw new KeyNotFoundException(
                    $"DealerPayment with ID {paymentId} does not exist."
                );
            if (payment.Status != DealerPaymentStatus.Pending)
                throw new InvalidOperationException("DealerPayment's Status is not Pending.");
            payment.Status = DealerPaymentStatus.Failed;
            _repository.Update(payment);
            await _repository.SaveChangesAsync();

            // Set order status to Canceled
            var dealerOrder =
                await _dealerOrderRepository.GetByIdAsync(payment.DealerOrderId)
                ?? throw new KeyNotFoundException(
                    $"DealerOrder with ID {payment.DealerOrderId} does not exist."
                );
            dealerOrder.Status = DealerOrderStatus.Canceled;
            _dealerOrderRepository.Update(dealerOrder);
            await _dealerOrderRepository.SaveChangesAsync();

            // Increase variant quantity in OEM inventory
            var variant =
                await _vehicleVariantRepository.GetByIdAsync(dealerOrder.VariantId)
                ?? throw new KeyNotFoundException(
                    $"VehicleVariant with ID {dealerOrder.VariantId} does not exist."
                );
            var oemInventory =
                (
                    await _oemInventoryRepository.FindAsync(i => i.VariantId == variant.Id)
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"OEM Inventory for Variant ID {variant.Id} does not exist."
                );
            oemInventory.Quantity += dealerOrder.Quantity;
            _oemInventoryRepository.Update(oemInventory);
            await _oemInventoryRepository.SaveChangesAsync();

            // Reduce dealer's outstanding debt
            var contract =
                (
                    await _dealerContractRepository.FindAsync(c =>
                        c.DealerId == dealerOrder.DealerId && c.StartDate <= Now && c.EndDate >= Now
                    )
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"No active contracts found for dealer with ID: {dealerOrder.DealerId}."
                );
            contract.OutstandingDebt -= payment.Amount;
            _dealerContractRepository.Update(contract);
            await _dealerContractRepository.SaveChangesAsync();
        }
    }
}
