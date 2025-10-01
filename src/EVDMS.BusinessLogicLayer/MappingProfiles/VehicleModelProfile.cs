using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelDto>();
            CreateMap<CreateVehicleModelDto, VehicleModel>(MemberList.Source);
            CreateMap<UpdateVehicleModelDto, VehicleModel>(MemberList.Source);
            CreateMap<PatchVehicleModelDto, VehicleModel>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
