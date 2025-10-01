using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class SalesOrderService
        : BaseService<
            SalesOrder,
            SalesOrderDto,
            CreateSalesOrderDto,
            UpdateSalesOrderDto,
            PatchSalesOrderDto
        >,
            ISalesOrderService
    {
        public SalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper)
            : base(salesOrderRepository, mapper) { }
    }
}
