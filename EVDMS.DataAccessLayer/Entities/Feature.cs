namespace EVDMS.DataAccessLayer.Entities
{
    public class Feature : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public required string FeatureName { get; set; }
        public required FeatureCategory FeatureCategory { get; set; }
        public ICollection<VariantFeature> VariantFeatures { get; set; } = [];
    }
}
