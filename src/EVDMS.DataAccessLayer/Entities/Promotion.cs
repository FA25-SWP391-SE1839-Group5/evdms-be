using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Promotion : BaseEntity
    {
        public Guid? DealerId { get; set; }
        public PromotionType Type { get; set; }
        public required string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Dealer? Dealer { get; set; }

        public static readonly string[] SearchableColumns =
        [
            "DealerId",
            "Type",
            "Description",
            "DiscountPercent",
            "StartDate",
            "EndDate",
        ];
    }
}
