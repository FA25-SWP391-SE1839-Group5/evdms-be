using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
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

        [NotMapped]
        public VehicleSpecs SpecsObject
        {
            get =>
                string.IsNullOrWhiteSpace(Specs)
                    ? new VehicleSpecs()
                    : JsonSerializer.Deserialize<VehicleSpecs>(Specs) ?? new VehicleSpecs();
            set => Specs = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public VehicleFeatures FeaturesObject
        {
            get =>
                string.IsNullOrWhiteSpace(Features)
                    ? new VehicleFeatures()
                    : JsonSerializer.Deserialize<VehicleFeatures>(Features)
                        ?? new VehicleFeatures();
            set => Features = JsonSerializer.Serialize(value);
        }
    }
}
