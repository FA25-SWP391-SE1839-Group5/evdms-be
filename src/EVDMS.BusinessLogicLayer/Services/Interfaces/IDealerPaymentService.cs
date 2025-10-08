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
        Task MarkAsPaidAsync(string paymentIntentId);
        Task MarkAsPendingAsync(string paymentIntentId);
        Task MarkAsFailedAsync(string paymentIntentId);
    }
}
