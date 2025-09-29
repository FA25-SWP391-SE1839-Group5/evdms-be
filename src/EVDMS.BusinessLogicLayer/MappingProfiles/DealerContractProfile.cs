using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerContractProfile : Profile
    {
        public DealerContractProfile()
        {
            CreateMap<DealerContract, DealerContractDto>();
            CreateMap<CreateDealerContractDto, DealerContract>(MemberList.Source);
            CreateMap<UpdateDealerContractDto, DealerContract>(MemberList.Source);
            CreateMap<PatchDealerContractDto, DealerContract>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
