using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<CreateVehicleDto, Vehicle>(MemberList.Source);
            CreateMap<UpdateVehicleDto, Vehicle>(MemberList.Source);
            CreateMap<PatchVehicleDto, Vehicle>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
