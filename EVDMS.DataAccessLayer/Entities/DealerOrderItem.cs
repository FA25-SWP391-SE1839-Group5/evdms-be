namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid VariantId { get; set; }
        public Guid ColorId { get; set; }
        public int Quantity { get; set; }

        public required DealerOrder DealerOrder { get; set; }
        public required VehicleVariant VehicleVariant { get; set; }
        public required VehicleColor VehicleColor { get; set; }
    }
}