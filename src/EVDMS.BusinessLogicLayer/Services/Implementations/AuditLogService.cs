using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
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

        public async Task<string> ExportToCsvAsync()
        {
            var allLogs = await _auditLogRepository.FindAsync(_ => true);
            var dtos = _mapper.Map<IEnumerable<AuditLogDto>>(allLogs);
            var sb = new StringBuilder();
            sb.AppendLine("Id,UserId,Action,Description,CreatedAt,UpdatedAt");
            foreach (var log in dtos)
            {
                sb.AppendLine(
                    $"{log.Id},{log.UserId},{log.Action},\"{log.Description.Replace("\"", "\"\"")}\",{log.CreatedAt:O},{log.UpdatedAt:O}"
                );
            }
            return sb.ToString();
        }
    }
}
