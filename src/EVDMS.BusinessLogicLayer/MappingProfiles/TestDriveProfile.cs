using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class TestDriveProfile : Profile
    {
        public TestDriveProfile()
        {
            CreateMap<TestDrive, TestDriveDto>()
                .ForMember(
                    dest => dest.CustomerFullName,
                    opt => opt.MapFrom(src => src.Customer.FullName)
                )
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(dest => dest.VehicleVin, opt => opt.MapFrom(src => src.Vehicle.Vin));
            CreateMap<CreateTestDriveDto, TestDrive>(MemberList.Source);
            CreateMap<UpdateTestDriveDto, TestDrive>(MemberList.Source);
            CreateMap<PatchTestDriveDto, TestDrive>(MemberList.Source)
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
