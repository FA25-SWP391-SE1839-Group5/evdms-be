using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Settings;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IDealerPaymentRepository _dealerPaymentRepository;

        public CloudinaryService(
            IOptions<CloudinarySettings> cloudinarySettings,
            IVehicleModelRepository vehicleModelRepository,
            IDealerPaymentRepository dealerPaymentRepository
        )
        {
            var settings = cloudinarySettings.Value;
            _cloudinary = new Cloudinary(
                new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret)
            );
            _vehicleModelRepository = vehicleModelRepository;
            _dealerPaymentRepository = dealerPaymentRepository;
        }

        public async Task<UploadVehicleModelImageResponseDto?> UploadVehicleModelImageAsync(
            IFormFile image
        )
        {
            if (image == null || image.Length == 0)
                return null;

            await using var stream = image.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, stream),
                Folder = "EVDMS/VehicleModelImages",
                UseFilename = true,
                UniqueFilename = true,
                Tags = "vehicle,model,image",
                Context = new StringDictionary("alt=Vehicle model image"),
                Transformation = new Transformation()
                    .Width(1920)
                    .Height(1080)
                    .Crop("pad")
                    .Background("black"),
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            return new UploadVehicleModelImageResponseDto
            {
                ImageUrl = uploadResult.SecureUrl?.ToString(),
                ImagePublicId = uploadResult.PublicId,
            };
        }

        public async Task<bool> DeleteVehicleModelImageAsync(Guid vehicleModelId)
        {
            var vehicleModel =
                await _vehicleModelRepository.GetByIdAsync(vehicleModelId)
                ?? throw new KeyNotFoundException(
                    $"VehicleModel with ID {vehicleModelId} does not exist."
                );
            if (string.IsNullOrEmpty(vehicleModel.ImagePublicId))
                return false;
            var deletionParams = new DeletionParams(vehicleModel.ImagePublicId)
            {
                ResourceType = ResourceType.Image,
                Type = "upload",
            };
            var result = await _cloudinary.DestroyAsync(deletionParams);
            if (result.Result == "ok")
            {
                vehicleModel.ImageUrl = null;
                vehicleModel.ImagePublicId = null;
                _vehicleModelRepository.Update(vehicleModel);
                await _vehicleModelRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UploadDealerPaymentDocumentResponseDto?> UploadDealerPaymentDocumentAsync(
            Guid dealerPaymentId,
            IFormFile document
        )
        {
            if (document == null || document.Length == 0)
                return null;
            if (!document.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                return null;

            var dealerPayment = await _dealerPaymentRepository.GetByIdAsync(dealerPaymentId);
            if (dealerPayment == null)
                return null;

            await using var stream = document.OpenReadStream();
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(document.FileName, stream),
                Folder = "EVDMS/DealerPaymentDocuments",
                UseFilename = true,
                UniqueFilename = true,
                Tags = "dealer,payment,document",
                Context = new StringDictionary("alt=Dealer payment document"),
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            dealerPayment.DocumentUrl = uploadResult.SecureUrl?.ToString();
            dealerPayment.DocumentPublicId = uploadResult.PublicId;
            _dealerPaymentRepository.Update(dealerPayment);
            await _dealerPaymentRepository.SaveChangesAsync();

            return new UploadDealerPaymentDocumentResponseDto
            {
                DocumentUrl = dealerPayment.DocumentUrl,
                PublicDocumentId = dealerPayment.DocumentPublicId,
            };
        }

        public async Task<bool> DeleteDealerPaymentDocumentAsync(Guid dealerPaymentId)
        {
            var dealerPayment =
                await _dealerPaymentRepository.GetByIdAsync(dealerPaymentId)
                ?? throw new KeyNotFoundException(
                    $"DealerPayment with ID {dealerPaymentId} does not exist."
                );
            if (string.IsNullOrEmpty(dealerPayment.DocumentPublicId))
                return false;
            var deletionParams = new DeletionParams(dealerPayment.DocumentPublicId)
            {
                ResourceType = ResourceType.Raw,
                Type = "upload",
            };
            var result = await _cloudinary.DestroyAsync(deletionParams);
            if (result.Result == "ok")
            {
                dealerPayment.DocumentUrl = null;
                dealerPayment.DocumentPublicId = null;
                _dealerPaymentRepository.Update(dealerPayment);
                await _dealerPaymentRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
