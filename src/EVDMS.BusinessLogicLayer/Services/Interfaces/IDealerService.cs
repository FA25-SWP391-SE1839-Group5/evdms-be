using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerService
        : IBaseService<DealerDto, CreateDealerDto, UpdateDealerDto, PatchDealerDto> { }
}
