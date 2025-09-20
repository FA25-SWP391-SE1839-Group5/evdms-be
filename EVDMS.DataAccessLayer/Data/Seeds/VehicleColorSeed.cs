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
            ];
    }
}
