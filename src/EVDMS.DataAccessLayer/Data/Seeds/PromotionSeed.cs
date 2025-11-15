using System.Globalization;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class PromotionSeed
    {
        public static List<Promotion> Promotions =>
            [
                // OEM promotions
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000003"),
                    Type = PromotionType.Oem,
                    Description = "Winter Sale: 5% off all vehicles!",
                    DiscountPercent = 5,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-03-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
                    Type = PromotionType.Oem,
                    Description = "Spring Sale: 10% off all vehicles!",
                    DiscountPercent = 10,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-03-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2026-03-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Type = PromotionType.Dealer,
                    Description = "Year-end Clearance: 15% off selected models!",
                    DiscountPercent = 15,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-12-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2026-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Type = PromotionType.Dealer,
                    Description = "Tet Special: 8% off",
                    DiscountPercent = 8,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-01-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                // Saigon Auto Hub (DealerId:30000000-0000-0000-0000-000000000002)
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Type = PromotionType.Dealer,
                    Description = "Anniversary Sale: 7% off",
                    DiscountPercent = 7,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-05-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-05-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000006"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Type = PromotionType.Dealer,
                    Description = "Summer Bonanza: 12% off!",
                    DiscountPercent = 12,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2025-06-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2025-12-30", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                // Hanoi EV Center (DealerId:30000000-0000-0000-0000-000000000003)
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000007"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Type = PromotionType.Dealer,
                    Description = "Grand Opening: 9% off",
                    DiscountPercent = 9,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-09-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-09-30", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000008"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Type = PromotionType.Dealer,
                    Description = "Hanoi Summer: 11% off!",
                    DiscountPercent = 11,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2025-05-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2026-05-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                // Da Nang Green Motors (DealerId:30000000-0000-0000-0000-000000000004)
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000009"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Type = PromotionType.Dealer,
                    Description = "Da Nang Launch: 6% off",
                    DiscountPercent = 6,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-03-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-03-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
                new Promotion
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000010"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Type = PromotionType.Dealer,
                    Description = "Da Nang Summer: 13% off!",
                    DiscountPercent = 13,
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-07-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2027-07-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                },
            ];
    }
}
