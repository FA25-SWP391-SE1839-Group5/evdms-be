namespace EVDMS.DataAccessLayer.Entities
{
    public class Spec : BaseEntity
    {
        public required string SpecName { get; set; }
        public required string Unit { get; set; }

        public ICollection<VariantSpec> VariantSpecs { get; set; } = [];
    }
}