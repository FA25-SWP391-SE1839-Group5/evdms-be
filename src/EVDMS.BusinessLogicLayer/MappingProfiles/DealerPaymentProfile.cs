using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerPaymentProfile : Profile
    {
        public DealerPaymentProfile()
        {
            CreateMap<DealerPayment, DealerPaymentDto>();
            CreateMap<CreateDealerPaymentDto, DealerPayment>(MemberList.Source);
            CreateMap<UpdateDealerPaymentDto, DealerPayment>(MemberList.Source);
            CreateMap<PatchDealerPaymentDto, DealerPayment>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
