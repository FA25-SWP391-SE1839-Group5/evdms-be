using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerOrderRepository : Repository<DealerOrder>, IDealerOrderRepository
    {
        public DealerOrderRepository(AppDbContext context)
            : base(context) { }
    }
}
