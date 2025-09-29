using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IVehicleModelService
        : IBaseService<
            VehicleModelDto,
            CreateVehicleModelDto,
            UpdateVehicleModelDto,
            PatchVehicleModelDto
        > { }
}
