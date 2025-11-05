using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(
                    dest => dest.VariantName,
                    opt => opt.MapFrom(src => src.VehicleVariant.Name)
                );
            CreateMap<CreateVehicleDto, Vehicle>(MemberList.Source);
            CreateMap<UpdateVehicleDto, Vehicle>(MemberList.Source);
            CreateMap<PatchVehicleDto, Vehicle>(MemberList.Source)
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember, context) =>
                            opts.DestinationMember.Name == nameof(Vehicle.Status)
                                ? src.Status.HasValue
                            : opts.DestinationMember.Name == nameof(Vehicle.Type)
                                ? src.Type.HasValue
                            : opts.DestinationMember.Name == nameof(Vehicle.Color)
                                ? src.Color.HasValue
                            : srcMember != null
                                && !(srcMember is Guid guid && guid == Guid.Empty)
                                && !(srcMember is DateTime dt && dt == default)
                    )
                );
        }
    }
}
