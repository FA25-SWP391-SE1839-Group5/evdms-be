namespace EVDMS.DataAccessLayer.Entities
{
    public class VehicleVariant : BaseEntity
    {
        public Guid ModelId { get; set; }
        public required string VariantName { get; set; }
        public decimal BasePrice { get; set; }

        public required VehicleModel VehicleModel { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = [];
        public ICollection<VariantSpec> VariantSpecs { get; set; } = [];
        public ICollection<VariantFeature> VariantFeatures { get; set; } = [];
        public ICollection<DealerOrderItem> DealerOrderItems { get; set; } = [];
    }
}