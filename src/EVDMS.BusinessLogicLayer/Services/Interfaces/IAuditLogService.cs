using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuditLogService
        : IBaseService<AuditLogDto, CreateAuditLogDto, UpdateAuditLogDto, PatchAuditLogDto>
    {
        Task<string> ExportToCsvAsync();
    }
}
