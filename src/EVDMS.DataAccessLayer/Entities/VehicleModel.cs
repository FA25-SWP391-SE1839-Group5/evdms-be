namespace EVDMS.DataAccessLayer.Entities
{
    public class VehicleModel : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<VehicleVariant> VehicleVariants { get; set; } = [];

        public static readonly string[] SearchableColumns = ["Name", "Description"];
    }
}
