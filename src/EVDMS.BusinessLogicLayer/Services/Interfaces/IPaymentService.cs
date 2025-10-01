using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IPaymentService
        : IBaseService<PaymentDto, CreatePaymentDto, UpdatePaymentDto, PatchPaymentDto> { }
}
