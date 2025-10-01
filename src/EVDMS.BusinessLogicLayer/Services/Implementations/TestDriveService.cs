using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class TestDriveService
        : BaseService<
            TestDrive,
            TestDriveDto,
            CreateTestDriveDto,
            UpdateTestDriveDto,
            PatchTestDriveDto
        >,
            ITestDriveService
    {
        public TestDriveService(ITestDriveRepository testDriveRepository, IMapper mapper)
            : base(testDriveRepository, mapper) { }
    }
}
