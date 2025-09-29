using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            CreateMap<Dealer, DealerDto>();
            CreateMap<CreateDealerDto, Dealer>(MemberList.Source);
            CreateMap<UpdateDealerDto, Dealer>(MemberList.Source);
            CreateMap<PatchDealerDto, Dealer>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
