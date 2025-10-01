using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(AppDbContext context)
            : base(context) { }
    }
}
