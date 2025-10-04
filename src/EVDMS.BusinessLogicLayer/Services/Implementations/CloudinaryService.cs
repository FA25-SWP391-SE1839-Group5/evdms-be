using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            var settings = cloudinarySettings.Value;
            _cloudinary = new Cloudinary(
                new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret)
            );
        }

        public async Task<string?> UploadVehicleModelImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return null;

            await using var stream = image.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, stream),
                Folder = "EVDMS/VehicleModels",
                UseFilename = true,
                UniqueFilename = true,
                Tags = "vehicle,model",
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

            return uploadResult.SecureUrl.ToString();
        }

        public async Task<bool> DeleteVehicleModelImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return false;
            try
            {
                var uri = new Uri(imageUrl);
                var path = uri.AbsolutePath;
                var uploadIndex = path.IndexOf("/upload/");
                if (uploadIndex == -1)
                    return false;
                var publicIdWithVersion = path.Substring(uploadIndex + 8);
                var segments = publicIdWithVersion.Split('/');
                if (
                    segments[0].StartsWith('v')
                    && segments[0].Length > 1
                    && int.TryParse(segments[0].AsSpan(1), out _)
                )
                {
                    segments = [.. segments.Skip(1)];
                }
                var publicIdWithExt = string.Join('/', segments);
                var lastDot = publicIdWithExt.LastIndexOf('.');
                var publicId =
                    lastDot > 0 ? publicIdWithExt.Substring(0, lastDot) : publicIdWithExt;
                var deletionParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deletionParams);
                return result.Result == "ok";
            }
            catch
            {
                return false;
            }
        }
    }
}
