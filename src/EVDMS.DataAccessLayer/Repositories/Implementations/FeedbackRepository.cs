using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context)
            : base(context) { }
    }
}
