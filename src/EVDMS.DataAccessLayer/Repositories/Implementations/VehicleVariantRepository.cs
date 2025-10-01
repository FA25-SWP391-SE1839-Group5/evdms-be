using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class VehicleVariantRepository : Repository<VehicleVariant>, IVehicleVariantRepository
    {
        public VehicleVariantRepository(AppDbContext context)
            : base(context) { }
    }
}
