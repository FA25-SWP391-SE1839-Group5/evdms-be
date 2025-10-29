using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICustomerService
        : IBaseService<CustomerDto, CreateCustomerDto, UpdateCustomerDto, PatchCustomerDto>
    {
        Task<CsvExportResult> ExportToCsvAsync();
    }
}
