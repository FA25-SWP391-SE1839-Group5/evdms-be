using Microsoft.AspNetCore.Http;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string?> UploadVehicleModelImageAsync(IFormFile image);
        Task<bool> DeleteVehicleModelImageAsync(string imageUrl);
    }
}
