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
        private readonly ISalesOrderService _salesOrderService;

        public ReportController(
            IDealerOrderService dealerOrderService,
            ISalesOrderService salesOrderService
        )
        {
            _dealerOrderService = dealerOrderService;
            _salesOrderService = salesOrderService;
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
            var csvBytes = Encoding.UTF8.GetBytes(result.CsvContent);
            var bom = Encoding.UTF8.GetPreamble();
            var bytesWithBom = new byte[bom.Length + csvBytes.Length];
            Buffer.BlockCopy(bom, 0, bytesWithBom, 0, bom.Length);
            Buffer.BlockCopy(csvBytes, 0, bytesWithBom, bom.Length, csvBytes.Length);
            return File(bytesWithBom, "application/octet-stream", result.FileName);
        }

        [HttpGet("dealer-staff-sales")]
        public async Task<IActionResult> GetDealerStaffSalesReport(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.GetDealerStaffSalesReportAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                startDate,
                endDate
            );
            return Ok(new ApiResponse<PaginatedResult<DealerStaffSalesReportDto>>(result));
        }

        [HttpGet("dealer-staff-sales/export")]
        public async Task<IActionResult> ExportDealerStaffSalesReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.ExportDealerStaffSalesReportToCsvAsync(
                startDate,
                endDate
            );
            var csvBytes = Encoding.UTF8.GetBytes(result.CsvContent);
            var bom = Encoding.UTF8.GetPreamble();
            var bytesWithBom = new byte[bom.Length + csvBytes.Length];
            Buffer.BlockCopy(bom, 0, bytesWithBom, 0, bom.Length);
            Buffer.BlockCopy(csvBytes, 0, bytesWithBom, bom.Length, csvBytes.Length);
            return File(bytesWithBom, "application/octet-stream", result.FileName);
        }

        [HttpGet("dealer-total-sales")]
        public async Task<IActionResult> GetDealerTotalSalesReport(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.GetDealerTotalSalesReportAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                startDate,
                endDate
            );
            return Ok(new ApiResponse<PaginatedResult<DealerTotalSalesReportDto>>(result));
        }

        [HttpGet("dealer-total-sales/export")]
        public async Task<IActionResult> ExportDealerTotalSalesReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.ExportDealerTotalSalesReportToCsvAsync(
                startDate,
                endDate
            );
            var csvBytes = Encoding.UTF8.GetBytes(result.CsvContent);
            var bom = Encoding.UTF8.GetPreamble();
            var bytesWithBom = new byte[bom.Length + csvBytes.Length];
            Buffer.BlockCopy(bom, 0, bytesWithBom, 0, bom.Length);
            Buffer.BlockCopy(csvBytes, 0, bytesWithBom, bom.Length, csvBytes.Length);
            return File(bytesWithBom, "application/octet-stream", result.FileName);
        }

        [HttpGet("region-sales")]
        public async Task<IActionResult> GetRegionSalesReport(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.GetRegionSalesReportAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                startDate,
                endDate
            );
            return Ok(new ApiResponse<PaginatedResult<RegionSalesReportDto>>(result));
        }

        [HttpGet("region-sales/export")]
        public async Task<IActionResult> ExportRegionSalesReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null
        )
        {
            var result = await _salesOrderService.ExportRegionSalesReportToCsvAsync(
                startDate,
                endDate
            );
            var csvBytes = Encoding.UTF8.GetBytes(result.CsvContent);
            var bom = Encoding.UTF8.GetPreamble();
            var bytesWithBom = new byte[bom.Length + csvBytes.Length];
            Buffer.BlockCopy(bom, 0, bytesWithBom, 0, bom.Length);
            Buffer.BlockCopy(csvBytes, 0, bytesWithBom, bom.Length, csvBytes.Length);
            return File(bytesWithBom, "application/octet-stream", result.FileName);
        }
    }
}
