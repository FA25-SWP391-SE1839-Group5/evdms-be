using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class QuotationRepository : Repository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(AppDbContext context)
            : base(context) { }
    }
}
