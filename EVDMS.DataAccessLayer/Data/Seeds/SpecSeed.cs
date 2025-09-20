using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class SpecSeed
    {
        public static List<Spec> Specs =>
            [
                new Spec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    SpecName = "Engine Displacement",
                    Unit = "cc",
                },
                new Spec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    SpecName = "Horsepower",
                    Unit = "hp",
                },
                new Spec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    SpecName = "Torque",
                    Unit = "Nm",
                },
                new Spec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    SpecName = "Fuel Tank Capacity",
                    Unit = "L",
                },
                new Spec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    SpecName = "Length",
                    Unit = "mm",
                },
                new Spec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    SpecName = "Width",
                    Unit = "mm",
                },
                new Spec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    SpecName = "Height",
                    Unit = "mm",
                },
                new Spec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    SpecName = "Wheelbase",
                    Unit = "mm",
                },
                new Spec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    SpecName = "Curb Weight",
                    Unit = "kg",
                },
                new Spec
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    SpecName = "Ground Clearance",
                    Unit = "mm",
                },
                new Spec
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    SpecName = "Seating Capacity",
                    Unit = "persons",
                },
            ];
    }
}
