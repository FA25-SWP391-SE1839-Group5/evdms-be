namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid VariantId { get; set; }
        public Guid ColorId { get; set; }
        public int Quantity { get; set; }

        public DealerOrder DealerOrder { get; set; } = null!;
        public VehicleVariant VehicleVariant { get; set; } = null!;
        public VehicleColor VehicleColor { get; set; } = null!;
    }
}
