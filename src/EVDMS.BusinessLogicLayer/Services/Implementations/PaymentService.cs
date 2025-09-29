using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class PaymentService
        : BaseService<Payment, PaymentDto, CreatePaymentDto, UpdatePaymentDto, PatchPaymentDto>,
            IPaymentService
    {
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
            : base(paymentRepository, mapper) { }
    }
}
