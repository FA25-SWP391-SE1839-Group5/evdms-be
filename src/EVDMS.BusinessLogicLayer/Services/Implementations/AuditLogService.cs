using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class AuditLogService
        : BaseService<
            AuditLog,
            AuditLogDto,
            CreateAuditLogDto,
            UpdateAuditLogDto,
            PatchAuditLogDto
        >,
            IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository, IMapper mapper)
            : base(auditLogRepository, mapper)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<CsvExportResult> ExportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            var allLogs = await _auditLogRepository.FindAsync(log =>
                (!startDate.HasValue || log.CreatedAt >= startDate.Value)
                && (!endDate.HasValue || log.CreatedAt <= endDate.Value)
            );
            var dtos = _mapper.Map<IEnumerable<AuditLogDto>>(allLogs);
            var sb = new StringBuilder();
            sb.AppendLine("Id,UserId,Action,Description,CreatedAt,UpdatedAt");
            foreach (var log in dtos)
            {
                sb.AppendLine(
                    $"{log.Id},{log.UserId},{log.Action},{CsvUtils.EscapeCsv(log.Description)},{log.CreatedAt:O},{log.UpdatedAt:O}"
                );
            }
            var fileName = CsvUtils.BuildCsvFileName("evdms_audit_logs", startDate, endDate);
            return new CsvExportResult { FileName = fileName, CsvContent = sb.ToString() };
        }
    }
}
