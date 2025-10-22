using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ISalesOrderService
        : IBaseService<SalesOrderDto, CreateSalesOrderDto, UpdateSalesOrderDto, PatchSalesOrderDto>
    {
        Task<SalesOrderDto> CreateAsync(CreateSalesOrderDto dto, Guid userId);
    }
}
