using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<UploadVehicleModelImageResponseDto?> UploadVehicleModelImageAsync(IFormFile image);
        Task<bool> DeleteVehicleModelImageAsync(Guid vehicleModelId);
        Task<UploadDealerPaymentDocumentResponseDto?> UploadDealerPaymentDocumentAsync(
            Guid dealerPaymentId,
            IFormFile document
        );
        Task<bool> DeleteDealerPaymentDocumentAsync(Guid dealerPaymentId);
    }
}
