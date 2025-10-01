using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(AppDbContext context)
            : base(context) { }
    }
}
