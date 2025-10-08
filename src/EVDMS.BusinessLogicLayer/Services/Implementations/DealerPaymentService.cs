using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerPaymentService
        : BaseService<
            DealerPayment,
            DealerPaymentDto,
            CreateDealerPaymentDto,
            UpdateDealerPaymentDto,
            PatchDealerPaymentDto
        >,
            IDealerPaymentService
    {
        public DealerPaymentService(
            IDealerPaymentRepository dealerPaymentRepository,
            IMapper mapper
        )
            : base(dealerPaymentRepository, mapper) { }
    }
}
