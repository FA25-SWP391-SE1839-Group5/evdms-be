using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class OemInventoryRepository : Repository<OemInventory>, IOemInventoryRepository
    {
        public OemInventoryRepository(AppDbContext context)
            : base(context) { }
    }
}
