using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerPayment : BaseEntity
    {
        public Guid DealerOrderId { get; set; }
        public decimal Amount { get; set; }
        public required DealerPaymentStatus Status { get; set; }
        public string? DocumentUrl { get; set; }

        public DealerOrder DealerOrder { get; set; } = null!;

        public static readonly string[] SearchableColumns = ["Amount", "Status"];
    }
}
