using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context)
            : base(context) { }
    }
}
