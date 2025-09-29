using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ITestDriveService
        : IBaseService<TestDriveDto, CreateTestDriveDto, UpdateTestDriveDto, PatchTestDriveDto> { }
}
