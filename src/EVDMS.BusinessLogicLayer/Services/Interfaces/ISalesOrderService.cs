using System.Threading.Tasks;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ISalesOrderService
        : IBaseService<SalesOrderDto, CreateSalesOrderDto, UpdateSalesOrderDto, PatchSalesOrderDto>
    {
        Task<SalesOrderDto> CreateAsync(CreateSalesOrderDto dto, Guid userId);
        Task DeliverAsync(Guid salesOrderId);
        Task<SalesOrderSummaryDto> GetSummaryAsync(Guid salesOrderId);
    }
}
