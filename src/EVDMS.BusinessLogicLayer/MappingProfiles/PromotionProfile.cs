using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Promotion, PromotionDto>();
            CreateMap<CreatePromotionDto, Promotion>(MemberList.Source);
            CreateMap<UpdatePromotionDto, Promotion>(MemberList.Source);
            CreateMap<PatchPromotionDto, Promotion>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
