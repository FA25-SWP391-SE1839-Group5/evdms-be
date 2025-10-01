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
        public AuditLogService(IAuditLogRepository auditLogRepository, IMapper mapper)
            : base(auditLogRepository, mapper) { }
    }
}
