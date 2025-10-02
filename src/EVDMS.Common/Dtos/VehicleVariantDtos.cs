using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EVDMS.Common.Enums;
using EVDMS.Common.Helpers;

namespace EVDMS.Common.Dtos
{
    public class VehicleVariantDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }

        [JsonIgnore]
        public VehicleSpecs Specs { get; set; } = new VehicleSpecs();

        [JsonPropertyName("specs")]
        public Dictionary<string, SpecDetail> AvailableSpecs =>
            typeof(VehicleSpecs)
                .GetProperties()
                .Where(p => p.GetValue(Specs) is SpecDetail sd && sd != null)
                .ToDictionary(p => p.Name, p => (SpecDetail)p.GetValue(Specs)!);

        [JsonIgnore]
        public VehicleFeatures Features { get; set; } = new VehicleFeatures();

        [JsonPropertyName("features")]
        public Dictionary<string, List<FeatureType>> AvailableFeatures =>
            typeof(VehicleFeatures)
                .GetProperties()
                .Where(p =>
                    p.GetValue(Features) is List<FeatureType> list && list != null && list.Count > 0
                )
                .ToDictionary(p => p.Name, p => (List<FeatureType>)p.GetValue(Features)!);

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVehicleVariantDto
    {
        [Required]
        public required Guid ModelId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required decimal BasePrice { get; set; }

        public VehicleSpecs? Specs { get; set; }

        public VehicleFeatures? Features { get; set; }
    }

    public class UpdateVehicleVariantDto
    {
        [Required]
        public required Guid ModelId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required decimal BasePrice { get; set; }

        [Required]
        public required VehicleSpecs Specs { get; set; }

        [Required]
        public required VehicleFeatures Features { get; set; }
    }

    public class PatchVehicleVariantDto
    {
        public Guid? ModelId { get; set; }

        public string? Name { get; set; }

        public decimal? BasePrice { get; set; }

        public VehicleSpecs? Specs { get; set; }

        public VehicleFeatures? Features { get; set; }
    }
}
