using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerContractService
        : BaseService<
            DealerContract,
            DealerContractDto,
            CreateDealerContractDto,
            UpdateDealerContractDto,
            PatchDealerContractDto
        >,
            IDealerContractService
    {
        public DealerContractService(
            IDealerContractRepository dealerContractRepository,
            IMapper mapper
        )
            : base(dealerContractRepository, mapper) { }
    }
}
