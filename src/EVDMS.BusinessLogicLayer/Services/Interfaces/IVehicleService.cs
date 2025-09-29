using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IVehicleService
        : IBaseService<VehicleDto, CreateVehicleDto, UpdateVehicleDto, PatchVehicleDto> { }
}
