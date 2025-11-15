using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuditLogService
        : IBaseService<AuditLogDto, CreateAuditLogDto, UpdateAuditLogDto, PatchAuditLogDto>
    {
        Task<CsvExportResult> ExportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        );
    }
}
