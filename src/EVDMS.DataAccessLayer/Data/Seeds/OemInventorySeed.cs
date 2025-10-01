using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class OemInventorySeed
    {
        public static List<OemInventory> OemInventories =>
            [
                new OemInventory
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Quantity = 10,
                },
                new OemInventory
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Quantity = 5,
                },
                new OemInventory
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000003"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    Quantity = 8,
                },
            ];
    }
}
