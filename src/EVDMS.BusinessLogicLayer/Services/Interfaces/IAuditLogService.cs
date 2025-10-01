using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuditLogService
        : IBaseService<AuditLogDto, CreateAuditLogDto, UpdateAuditLogDto, PatchAuditLogDto> { }
}
