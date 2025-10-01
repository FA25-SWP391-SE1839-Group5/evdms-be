using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IVehicleVariantService
        : IBaseService<
            VehicleVariantDto,
            CreateVehicleVariantDto,
            UpdateVehicleVariantDto,
            PatchVehicleVariantDto
        > { }
}
