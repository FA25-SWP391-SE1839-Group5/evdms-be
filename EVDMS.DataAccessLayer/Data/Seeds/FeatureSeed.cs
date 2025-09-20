using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class FeatureSeed
    {
        public static List<Feature> Features =>
            [
                // Convenience
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Adaptive Cruise Control",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Cooled Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Heated Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Heated Steering Wheel",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Keyless Entry",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Keyless Start",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Navigation System",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Remote Start",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Power Liftgate",
                },
                new Feature
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FeatureName = "Rain Sensing Wipers",
                },
                // Entertainment
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "Android Auto®",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "Apple CarPlay®",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "Bluetooth®",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "HomeLink",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "Premium Sound System",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "USB Port",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "WiFi Hotspot",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "Satellite Radio",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "CD Player",
                },
                new Feature
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FeatureName = "AUX Input",
                },
                // Exterior
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Alloy Wheels",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Tow Hitch",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Tow Hooks",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Fog Lights",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Roof Rails",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Sunroof",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Power Mirrors",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Rear Spoiler",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000009"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Automatic Headlights",
                },
                new Feature
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FeatureName = "Daytime Running Lights",
                },
                // Safety
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Automatic Emergency Braking",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Backup Camera",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Blind Spot Monitor",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Brake Assist",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "LED Headlights",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Lane Departure Warning",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Rear Cross Traffic Alert",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000008"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Stability Control",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000009"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Traction Control",
                },
                new Feature
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000010"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FeatureName = "Parking Sensors",
                },
                // Seating
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Leather Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Memory Seat",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000003"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Power Driver Seat",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000004"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Power Passenger Seat",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000005"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Heated Rear Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000006"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Ventilated Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000007"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Split Folding Rear Seat",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000008"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Adjustable Lumbar Support",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000009"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Bucket Seats",
                },
                new Feature
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000010"),
                    CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FeatureName = "Third Row Seating",
                },
            ];
    }
}
