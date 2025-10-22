using System.Threading.Tasks;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;

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
