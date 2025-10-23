using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerPaymentService
        : IBaseService<
            DealerPaymentDto,
            CreateDealerPaymentDto,
            UpdateDealerPaymentDto,
            PatchDealerPaymentDto
        >
    {
        Task MarkPaymentPaidAsync(Guid paymentId);
        Task MarkPaymentFailedAsync(Guid paymentId);
    }
}
