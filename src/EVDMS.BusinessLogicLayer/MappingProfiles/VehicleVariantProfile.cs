using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class VehicleVariantProfile : Profile
    {
        public VehicleVariantProfile()
        {
            CreateMap<VehicleVariant, VehicleVariantDto>();
            CreateMap<CreateVehicleVariantDto, VehicleVariant>(MemberList.Source);
            CreateMap<UpdateVehicleVariantDto, VehicleVariant>(MemberList.Source);
            CreateMap<PatchVehicleVariantDto, VehicleVariant>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
