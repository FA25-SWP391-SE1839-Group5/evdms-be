namespace EVDMS.DataAccessLayer.Entities
{
    public class VariantFeature : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsAvailable { get; set; }

        public VehicleVariant VehicleVariant { get; set; } = null!;
        public Feature Feature { get; set; } = null!;
    }
}
