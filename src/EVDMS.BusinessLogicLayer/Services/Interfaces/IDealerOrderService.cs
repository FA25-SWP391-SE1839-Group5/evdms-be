using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerOrderService
        : IBaseService<
            DealerOrderDto,
            CreateDealerOrderDto,
            UpdateDealerOrderDto,
            PatchDealerOrderDto
        > { }
}
