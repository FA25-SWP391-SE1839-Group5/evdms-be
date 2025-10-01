using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerService
        : BaseService<Dealer, DealerDto, CreateDealerDto, UpdateDealerDto, PatchDealerDto>,
            IDealerService
    {
        public DealerService(IDealerRepository dealerRepository, IMapper mapper)
            : base(dealerRepository, mapper) { }
    }
}
