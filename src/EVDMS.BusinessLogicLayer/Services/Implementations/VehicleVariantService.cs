using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleVariantService
        : BaseService<
            VehicleVariant,
            VehicleVariantDto,
            CreateVehicleVariantDto,
            UpdateVehicleVariantDto,
            PatchVehicleVariantDto
        >,
            IVehicleVariantService
    {
        public VehicleVariantService(
            IVehicleVariantRepository vehicleVariantRepository,
            IMapper mapper
        )
            : base(vehicleVariantRepository, mapper) { }
    }
}
