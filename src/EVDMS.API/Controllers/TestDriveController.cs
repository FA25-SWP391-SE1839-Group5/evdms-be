using System.Text.Json;
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
        private readonly ITestDriveService _testDriveService;

        public TestDriveController(ITestDriveService testDriveService)
        {
            _testDriveService = testDriveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] string? search = null,
            [FromQuery] string? filters = null
        )
        {
            Dictionary<string, string>? filterDict = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterDict = JsonSerializer.Deserialize<Dictionary<string, string>>(filters);
            }
            var result = await _testDriveService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.TestDrive.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<TestDriveDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var testDrive = await _testDriveService.GetByIdAsync(id);
            if (testDrive == null)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<TestDriveDto>(testDrive));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestDriveDto dto)
        {
            var created = await _testDriveService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<TestDriveDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTestDriveDto dto)
        {
            var success = await _testDriveService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            var updated = await _testDriveService.GetByIdAsync(id);
            return Ok(new ApiResponse<TestDriveDto>(updated!, "TestDrive updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchTestDriveDto dto)
        {
            var success = await _testDriveService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            var updated = await _testDriveService.GetByIdAsync(id);
            return Ok(new ApiResponse<TestDriveDto>(updated!, "TestDrive patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _testDriveService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("TestDrive not found"));
            return Ok(new ApiResponse<string>(null, "TestDrive deleted successfully"));
        }
    }
}
