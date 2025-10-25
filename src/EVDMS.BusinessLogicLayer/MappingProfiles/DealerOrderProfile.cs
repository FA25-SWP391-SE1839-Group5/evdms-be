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

            CreateMap<CreateDealerOrderDto, DealerOrder>(MemberList.Source)
                .ForMember(dest => dest.DealerId, opt => opt.Ignore());
            CreateMap<UpdateDealerOrderDto, DealerOrder>(MemberList.Source);
            CreateMap<PatchDealerOrderDto, DealerOrder>(MemberList.Source)
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
