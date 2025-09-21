using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class FeatureCategorySeed
    {
        public static List<FeatureCategory> FeatureCategories =>
            [
                new FeatureCategory { Id = FeatureCategoryIds.Safety, CategoryName = "Safety" },
                new FeatureCategory
                {
                    Id = FeatureCategoryIds.Convenience,
                    CategoryName = "Convenience",
                },
                new FeatureCategory
                {
                    Id = FeatureCategoryIds.Entertainment,
                    CategoryName = "Entertainment",
                },
                new FeatureCategory { Id = FeatureCategoryIds.Exterior, CategoryName = "Exterior" },
                new FeatureCategory { Id = FeatureCategoryIds.Seating, CategoryName = "Seating" },
            ];
    }
}
