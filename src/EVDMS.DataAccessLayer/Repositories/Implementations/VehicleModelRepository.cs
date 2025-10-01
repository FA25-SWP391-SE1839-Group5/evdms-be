using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class VehicleModelRepository : Repository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context)
            : base(context) { }
    }
}
