namespace EVDMS.DataAccessLayer.Entities
{
    public class VariantSpec : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid SpecId { get; set; }
        public required string Value { get; set; }

        public VehicleVariant VehicleVariant { get; set; } = null!;
        public Spec Spec { get; set; } = null!;
    }
}
