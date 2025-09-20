using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class FeatureCategorySeed
    {
        public static List<FeatureCategory> FeatureCategories =>
            [
                new FeatureCategory
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    CategoryName = "Safety",
                },
                new FeatureCategory
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    CategoryName = "Convenience",
                },
                new FeatureCategory
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    CategoryName = "Entertainment",
                },
                new FeatureCategory
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    CategoryName = "Exterior",
                },
                new FeatureCategory
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    CategoryName = "Seating",
                },
            ];
    }
}
