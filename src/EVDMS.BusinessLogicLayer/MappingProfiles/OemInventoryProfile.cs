using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class OemInventoryProfile : Profile
    {
        public OemInventoryProfile()
        {
            CreateMap<OemInventory, OemInventoryDto>()
                .ForMember(
                    dest => dest.VariantName,
                    opt => opt.MapFrom(src => src.VehicleVariant.Name)
                );
            CreateMap<CreateOemInventoryDto, OemInventory>(MemberList.Source);
            CreateMap<UpdateOemInventoryDto, OemInventory>(MemberList.Source);
            CreateMap<PatchOemInventoryDto, OemInventory>(MemberList.Source)
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
