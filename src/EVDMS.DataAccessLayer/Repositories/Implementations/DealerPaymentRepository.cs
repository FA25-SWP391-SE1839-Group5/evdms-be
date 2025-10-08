using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerPaymentRepository : Repository<DealerPayment>, IDealerPaymentRepository
    {
        public DealerPaymentRepository(AppDbContext context)
            : base(context) { }
    }
}
