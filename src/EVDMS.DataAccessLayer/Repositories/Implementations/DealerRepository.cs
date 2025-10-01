using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerRepository : Repository<Dealer>, IDealerRepository
    {
        public DealerRepository(AppDbContext context)
            : base(context) { }
    }
}
