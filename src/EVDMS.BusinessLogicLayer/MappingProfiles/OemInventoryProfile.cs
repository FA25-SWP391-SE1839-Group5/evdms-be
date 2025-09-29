using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class OemInventoryProfile : Profile
    {
        public OemInventoryProfile()
        {
            CreateMap<OemInventory, OemInventoryDto>();
            CreateMap<CreateOemInventoryDto, OemInventory>(MemberList.Source);
            CreateMap<UpdateOemInventoryDto, OemInventory>(MemberList.Source);
            CreateMap<PatchOemInventoryDto, OemInventory>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
