using System;
using System.Threading.Tasks;
using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ITestDriveService
        : IBaseService<TestDriveDto, CreateTestDriveDto, UpdateTestDriveDto, PatchTestDriveDto>
    {
        Task<TestDriveDto> CreateAsync(CreateTestDriveDto dto, Guid dealerId);
    }
}
