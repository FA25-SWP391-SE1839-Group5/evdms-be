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
        > { }
}
