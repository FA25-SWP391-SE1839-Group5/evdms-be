using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerOrderService
        : IBaseService<
            DealerOrderDto,
            CreateDealerOrderDto,
            UpdateDealerOrderDto,
            PatchDealerOrderDto
        >
    {
        Task<DealerOrderDto> CreateAsync(Guid dealerId, CreateDealerOrderDto dto);
        Task DeliverOrderAsync(Guid orderId, Guid userId);
        Task<PaginatedResult<VariantOrderRateDto>> GetDeliveredOrdersByVariantAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        );
        Task<CsvExportResult> ExportDeliveredOrdersByVariantToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        );
    }
}
