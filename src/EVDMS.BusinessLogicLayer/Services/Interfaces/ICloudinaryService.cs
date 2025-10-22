using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<UploadVehicleModelImageResponseDto?> UploadVehicleModelImageAsync(IFormFile image);
        Task<bool> DeleteVehicleModelImageAsync(Guid vehicleModelId);
        Task<string?> UploadDealerPaymentDocumentAsync(IFormFile document);
        Task<bool> DeleteDealerPaymentDocumentAsync(string documentUrl);
    }
}
