using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerOrderService
        : BaseService<
            DealerOrder,
            DealerOrderDto,
            CreateDealerOrderDto,
            UpdateDealerOrderDto,
            PatchDealerOrderDto
        >,
            IDealerOrderService
    {
        public DealerOrderService(IDealerOrderRepository dealerOrderRepository, IMapper mapper)
            : base(dealerOrderRepository, mapper) { }
    }
}
