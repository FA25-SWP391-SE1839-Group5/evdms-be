using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class PaymentService
        : BaseService<Payment, PaymentDto, CreatePaymentDto, UpdatePaymentDto, PatchPaymentDto>,
            IPaymentService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IQuotationRepository _quotationRepository;

        public PaymentService(
            IPaymentRepository paymentRepository,
            ISalesOrderRepository salesOrderRepository,
            IQuotationRepository quotationRepository,
            IMapper mapper
        )
            : base(paymentRepository, mapper)
        {
            _salesOrderRepository = salesOrderRepository;
            _quotationRepository = quotationRepository;
        }

        public override async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var salesOrder =
                await _salesOrderRepository.GetByIdAsync(dto.SalesOrderId)
                ?? throw new KeyNotFoundException(
                    $"SalesOrder with ID {dto.SalesOrderId} does not exist."
                );

            if (salesOrder.Status != SalesOrderStatus.Pending)
                throw new InvalidOperationException(
                    "Payments can only be created for sales orders with status Pending."
                );

            var quotation =
                await _quotationRepository.GetByIdAsync(salesOrder.QuotationId)
                ?? throw new KeyNotFoundException(
                    $"Quotation with ID {salesOrder.QuotationId} does not exist."
                );

            decimal fullAmount = quotation.TotalAmount;
            Payment payment = _mapper.Map<Payment>(dto);
            payment.Date = DateTime.UtcNow;

            if (dto.Method == PaymentMethod.Upfront)
            {
                payment.Amount = fullAmount;
                salesOrder.Status = SalesOrderStatus.Confirmed;
                _salesOrderRepository.Update(salesOrder);
                await _salesOrderRepository.SaveChangesAsync();
            }
            else if (dto.Method == PaymentMethod.Installment)
            {
                var previousPayments = await _repository.FindAsync(p =>
                    p.SalesOrderId == dto.SalesOrderId
                );
                decimal totalPaid = previousPayments.Sum(p => p.Amount) + dto.Amount;
                if (totalPaid >= fullAmount)
                {
                    salesOrder.Status = SalesOrderStatus.Confirmed;
                    _salesOrderRepository.Update(salesOrder);
                    await _salesOrderRepository.SaveChangesAsync();
                }
            }

            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<PaymentDto>(payment);
        }
    }
}
