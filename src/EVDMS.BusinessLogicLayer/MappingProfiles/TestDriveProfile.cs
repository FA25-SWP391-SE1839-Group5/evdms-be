using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class TestDriveProfile : Profile
    {
        public TestDriveProfile()
        {
            CreateMap<TestDrive, TestDriveDto>();
            CreateMap<CreateTestDriveDto, TestDrive>(MemberList.Source);
            CreateMap<UpdateTestDriveDto, TestDrive>(MemberList.Source);
            CreateMap<PatchTestDriveDto, TestDrive>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
