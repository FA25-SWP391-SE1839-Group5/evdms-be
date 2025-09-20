namespace EVDMS.DataAccessLayer.Entities
{
    public class VariantSpec : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid SpecId { get; set; }
        public required string Value { get; set; }

        public required VehicleVariant VehicleVariant { get; set; }
        public required Spec Spec { get; set; }
    }
}
