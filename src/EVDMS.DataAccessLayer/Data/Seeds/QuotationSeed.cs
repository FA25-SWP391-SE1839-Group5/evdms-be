using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class QuotationSeed
    {
        public static List<Quotation> Quotations =>
            [
                new Quotation
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Status = QuotationStatus.Sent,
                },
                new Quotation
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Status = QuotationStatus.Approved,
                },
            ];
    }
}
