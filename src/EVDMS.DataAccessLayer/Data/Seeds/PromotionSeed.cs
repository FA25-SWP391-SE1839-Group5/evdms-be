using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class PromotionSeed
    {
        public static List<Promotion> Promotions =>
            [
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
                    Type = PromotionType.Oem,
                    Description = "Spring Sale: 10% off all vehicles!",
                    DiscountPercent = 10,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-03-01"),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(DateTime.Parse("2024-03-31"), DateTimeKind.Utc),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Type = PromotionType.Dealer,
                    Description = "Year-end Clearance: 15% off selected models!",
                    DiscountPercent = 15,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-12-01"),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(DateTime.Parse("2024-12-31"), DateTimeKind.Utc),
                },
            ];
    }
}
