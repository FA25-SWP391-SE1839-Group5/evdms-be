using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ISalesOrderService
        : IBaseService<
            SalesOrderDto,
            CreateSalesOrderDto,
            UpdateSalesOrderDto,
            PatchSalesOrderDto
        > { }
}
