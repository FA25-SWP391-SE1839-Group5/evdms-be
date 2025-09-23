using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleColorSeed
    {
        public static List<VehicleColor> VehicleColors =>
            [
                new VehicleColor
                {
                    Id = VehicleColorIds.Red,
                    ColorName = "Red",
                    HexCode = "#FF0000",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Blue,
                    ColorName = "Blue",
                    HexCode = "#0000FF",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Green,
                    ColorName = "Green",
                    HexCode = "#00FF00",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Black,
                    ColorName = "Black",
                    HexCode = "#000000",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.White,
                    ColorName = "White",
                    HexCode = "#FFFFFF",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Silver,
                    ColorName = "Silver",
                    HexCode = "#C0C0C0",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Gray,
                    ColorName = "Gray",
                    HexCode = "#808080",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Yellow,
                    ColorName = "Yellow",
                    HexCode = "#FFFF00",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Brown,
                    ColorName = "Brown",
                    HexCode = "#8B4513",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Orange,
                    ColorName = "Orange",
                    HexCode = "#FFA500",
                },
                new VehicleColor
                {
                    Id = VehicleColorIds.Beige,
                    ColorName = "Beige",
                    HexCode = "#F5F5DC",
                },
            ];
    }
}
