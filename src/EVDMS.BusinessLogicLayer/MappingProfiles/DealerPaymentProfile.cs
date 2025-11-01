using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerPaymentProfile : Profile
    {
        public DealerPaymentProfile()
        {
            CreateMap<DealerPayment, DealerPaymentDto>()
                .ForMember(
                    dest => dest.DealerId,
                    opt => opt.MapFrom(src => src.DealerOrder.DealerId)
                )
                .ForMember(
                    dest => dest.DealerName,
                    opt => opt.MapFrom(src => src.DealerOrder.Dealer.Name)
                );
            CreateMap<CreateDealerPaymentDto, DealerPayment>(MemberList.Source);
            CreateMap<UpdateDealerPaymentDto, DealerPayment>(MemberList.Source);
            CreateMap<PatchDealerPaymentDto, DealerPayment>(MemberList.Source)
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember, context) =>
                            srcMember != null
                            && !(srcMember is Guid guid && guid == Guid.Empty)
                            && !(srcMember is DateTime dt && dt == default)
                    )
                );
        }
    }
}
