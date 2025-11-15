using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerContractProfile : Profile
    {
        public DealerContractProfile()
        {
            CreateMap<DealerContract, DealerContractDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name));
            CreateMap<CreateDealerContractDto, DealerContract>(MemberList.Source)
                .ForMember(dest => dest.OutstandingDebt, opt => opt.MapFrom(src => 0m));
            CreateMap<UpdateDealerContractDto, DealerContract>(MemberList.Source);
            CreateMap<PatchDealerContractDto, DealerContract>(MemberList.Source)
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
