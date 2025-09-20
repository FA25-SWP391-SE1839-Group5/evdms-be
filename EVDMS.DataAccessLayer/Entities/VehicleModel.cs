namespace EVDMS.DataAccessLayer.Entities
{
    public class VehicleModel : BaseEntity
    {
        public required string ModelName { get; set; }
        public required string Description { get; set; }

        public ICollection<VehicleVariant> VehicleVariants { get; set; } = [];
    }
}