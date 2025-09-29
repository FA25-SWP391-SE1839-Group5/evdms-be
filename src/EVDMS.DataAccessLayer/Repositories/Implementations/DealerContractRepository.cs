using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerContractRepository : Repository<DealerContract>, IDealerContractRepository
    {
        public DealerContractRepository(AppDbContext context)
            : base(context) { }
    }
}
