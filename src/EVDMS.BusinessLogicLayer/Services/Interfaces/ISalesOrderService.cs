using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ISalesOrderService
        : IBaseService<SalesOrderDto, CreateSalesOrderDto, UpdateSalesOrderDto, PatchSalesOrderDto>
    {
        Task<SalesOrderDto> CreateAsync(CreateSalesOrderDto dto, Guid userId);
        Task DeliverAsync(Guid salesOrderId);
        Task<SalesOrderSummaryDto> GetSummaryAsync(Guid salesOrderId);
        Task<PaginatedResult<DealerStaffSalesReportDto>> GetDealerStaffSalesReportAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            Guid? dealerId = null
        );
        Task<CsvExportResult> ExportDealerStaffSalesReportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        );
        Task<PaginatedResult<DealerTotalSalesReportDto>> GetDealerTotalSalesReportAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        );
        Task<CsvExportResult> ExportDealerTotalSalesReportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        );
        Task<PaginatedResult<RegionSalesReportDto>> GetRegionSalesReportAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        );
        Task<CsvExportResult> ExportRegionSalesReportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        );
    }
}
