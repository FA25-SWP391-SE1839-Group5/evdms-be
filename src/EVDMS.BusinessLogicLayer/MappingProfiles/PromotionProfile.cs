using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Promotion, PromotionDto>()
                .ForMember(
                    dest => dest.DealerName,
                    opt => opt.MapFrom(src => src.Dealer != null ? src.Dealer.Name : null)
                );
            CreateMap<CreatePromotionDto, Promotion>(MemberList.Source);
            CreateMap<UpdatePromotionDto, Promotion>(MemberList.Source);
            CreateMap<PatchPromotionDto, Promotion>(MemberList.Source)
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
