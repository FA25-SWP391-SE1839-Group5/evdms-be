using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using EVDMS.Common.Helpers;

namespace EVDMS.DataAccessLayer.Entities
{
    public class VehicleVariant : BaseEntity
    {
        public Guid ModelId { get; set; }
        public required string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Specs { get; set; } = "{}";
        public string Features { get; set; } = "{}";

        public VehicleModel VehicleModel { get; set; } = null!;
        public ICollection<Vehicle> Vehicles { get; set; } = [];
        public ICollection<OemInventory> OemInventories { get; set; } = [];

        private static readonly JsonSerializerOptions IgnoreNullOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        [NotMapped]
        public VehicleSpecs SpecsObject
        {
            get =>
                string.IsNullOrWhiteSpace(Specs)
                    ? new VehicleSpecs()
                    : JsonSerializer.Deserialize<VehicleSpecs>(Specs, IgnoreNullOptions)
                        ?? new VehicleSpecs();
            set => Specs = JsonSerializer.Serialize(value, IgnoreNullOptions);
        }

        [NotMapped]
        public VehicleFeatures FeaturesObject
        {
            get =>
                string.IsNullOrWhiteSpace(Features)
                    ? new VehicleFeatures()
                    : JsonSerializer.Deserialize<VehicleFeatures>(Features, IgnoreNullOptions)
                        ?? new VehicleFeatures();
            set => Features = JsonSerializer.Serialize(value, IgnoreNullOptions);
        }

        public static readonly string[] SearchableColumns =
        [
            "ModelId",
            "Name",
            "BasePrice",
            "Specs",
            "Features",
        ];
    }
}
