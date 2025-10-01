namespace EVDMS.DataAccessLayer.Entities
{
    public class OemInventory : BaseEntity
    {
        public Guid VariantId { get; set; }
        public int Quantity { get; set; }

        public VehicleVariant VehicleVariant { get; set; } = null!;

        public static readonly string[] SearchableColumns = ["VariantId", "Quantity"];
    }
}
