using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerOrderProfile : Profile
    {
        public DealerOrderProfile()
        {
            CreateMap<DealerOrder, DealerOrderDto>();

            CreateMap<CreateDealerOrderDto, DealerOrder>(MemberList.Source);
            CreateMap<UpdateDealerOrderDto, DealerOrder>(MemberList.Source);
            CreateMap<PatchDealerOrderDto, DealerOrder>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
