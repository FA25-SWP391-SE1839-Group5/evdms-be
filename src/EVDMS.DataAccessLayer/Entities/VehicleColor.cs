namespace EVDMS.DataAccessLayer.Entities
{
    public class VehicleColor : BaseEntity
    {
        public required string ColorName { get; set; }
        public required string HexCode { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = [];
        public ICollection<DealerOrderItem> DealerOrderItems { get; set; } = [];
    }
}
