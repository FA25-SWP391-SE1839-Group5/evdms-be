using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleModelService
        : BaseService<
            VehicleModel,
            VehicleModelDto,
            CreateVehicleModelDto,
            UpdateVehicleModelDto,
            PatchVehicleModelDto
        >,
            IVehicleModelService
    {
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IMapper mapper)
            : base(vehicleModelRepository, mapper) { }
    }
}
