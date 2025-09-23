namespace EVDMS.DataAccessLayer.Entities
{
    public class Feature : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public required string FeatureName { get; set; }
        public FeatureCategory FeatureCategory { get; set; } = null!;
        public ICollection<VariantFeature> VariantFeatures { get; set; } = [];
    }
}
