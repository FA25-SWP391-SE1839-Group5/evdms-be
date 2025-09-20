using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleColorSeed
    {
        public static List<VehicleColor> VehicleColors =>
            [
                new VehicleColor
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ColorName = "Red",
                    HexCode = "#FF0000",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ColorName = "Blue",
                    HexCode = "#0000FF",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    ColorName = "Green",
                    HexCode = "#00FF00",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    ColorName = "Black",
                    HexCode = "#000000",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    ColorName = "White",
                    HexCode = "#FFFFFF",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    ColorName = "Silver",
                    HexCode = "#C0C0C0",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    ColorName = "Gray",
                    HexCode = "#808080",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    ColorName = "Yellow",
                    HexCode = "#FFFF00",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    ColorName = "Brown",
                    HexCode = "#8B4513",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    ColorName = "Orange",
                    HexCode = "#FFA500",
                },
                new VehicleColor
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    ColorName = "Beige",
                    HexCode = "#F5F5DC",
                },
            ];
    }
}
