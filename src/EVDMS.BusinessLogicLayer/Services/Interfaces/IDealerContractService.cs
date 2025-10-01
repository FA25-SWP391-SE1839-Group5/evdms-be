using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerContractService
        : IBaseService<
            DealerContractDto,
            CreateDealerContractDto,
            UpdateDealerContractDto,
            PatchDealerContractDto
        > { }
}
