using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrder : BaseEntity
    {
        public Guid DealerId { get; set; }
        public Guid VariantId { get; set; }
        public int Quantity { get; set; }
        public VehicleColor Color { get; set; }
        public DealerOrderStatus Status { get; set; }

        public Dealer Dealer { get; set; } = null!;
        public VehicleVariant VehicleVariant { get; set; } = null!;
        public ICollection<DealerPayment> DealerPayments { get; set; } = [];

        public static readonly string[] SearchableColumns = ["Quantity", "Color", "Status"];
    }
}
