using System.Text;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IDealerOrderService _dealerOrderService;

        public ReportController(IDealerOrderService dealerOrderService)
        {
            _dealerOrderService = dealerOrderService;
        }

        [HttpGet("variant-order-rates")]
        public async Task<IActionResult> GetVariantOrderRates(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _dealerOrderService.GetDeliveredOrdersByVariantAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                startDate,
                endDate
            );
            return Ok(new ApiResponse<PaginatedResult<VariantOrderRateDto>>(result));
        }

        [HttpGet("variant-order-rates/export")]
        public async Task<IActionResult> ExportVariantOrderRates(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _dealerOrderService.ExportDeliveredOrdersByVariantToCsvAsync(
                startDate,
                endDate
            );
            var bytes = Encoding.UTF8.GetBytes(result.CsvContent);
            return File(bytes, "text/csv", result.FileName);
        }
    }
}
