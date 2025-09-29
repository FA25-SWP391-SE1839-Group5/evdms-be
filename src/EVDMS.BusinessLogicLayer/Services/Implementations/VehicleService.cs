using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleService
        : BaseService<Vehicle, VehicleDto, CreateVehicleDto, UpdateVehicleDto, PatchVehicleDto>,
            IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
            : base(vehicleRepository, mapper) { }
    }
}
