namespace EVDMS.DataAccessLayer.Entities
{
    public class VariantFeature : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsAvailable { get; set; }

        public required VehicleVariant VehicleVariant { get; set; }
        public required Feature Feature { get; set; }
    }
}