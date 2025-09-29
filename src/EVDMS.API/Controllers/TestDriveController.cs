using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/test-drives")]
    public class TestDriveController : ControllerBase
    {
        private readonly ITestDriveService testDriveService;

        public TestDriveController(ITestDriveService testDriveService)
        {
            this.testDriveService = testDriveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await testDriveService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<TestDriveDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var testDrive = await testDriveService.GetByIdAsync(id);
            if (testDrive == null)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<TestDriveDto>(testDrive));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestDriveDto dto)
        {
            var created = await testDriveService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<TestDriveDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTestDriveDto dto)
        {
            var success = await testDriveService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<string>(null, "TestDrive updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchTestDriveDto dto)
        {
            var success = await testDriveService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<string>(null, "TestDrive patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await testDriveService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<string>(null, "TestDrive deleted successfully"));
        }
    }
}
