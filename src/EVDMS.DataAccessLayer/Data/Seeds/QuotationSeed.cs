using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class QuotationSeed
    {
        public static List<Quotation> Quotations =>
            [
                // EV Motors Saigon
                new Quotation
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Color = VehicleColor.White,
                    TotalAmount = 46630m,
                    Status = QuotationStatus.Sent,
                },
                new Quotation
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Color = VehicleColor.Black,
                    TotalAmount = 51300m,
                    Status = QuotationStatus.Approved,
                },
                // Hanoi EV Center
                new Quotation
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Color = VehicleColor.Gray,
                    TotalAmount = 50730m,
                    Status = QuotationStatus.Rejected,
                },
            ];
    }
}
