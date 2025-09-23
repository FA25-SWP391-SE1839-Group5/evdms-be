namespace EVDMS.DataAccessLayer.Entities
{
    public class Spec : BaseEntity
    {
        public Guid SpecCategoryId { get; set; }
        public required string SpecName { get; set; }
        public string? Unit { get; set; }

        public SpecCategory SpecCategory { get; set; } = null!;
        public ICollection<VariantSpec> VariantSpecs { get; set; } = [];
    }
}
