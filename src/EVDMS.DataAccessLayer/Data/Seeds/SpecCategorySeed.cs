using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class SpecCategorySeed
    {
        public static List<SpecCategory> SpecCategories =>
            [
                new SpecCategory { Id = SpecCategoryIds.Performance, Name = "Performance" },
                new SpecCategory { Id = SpecCategoryIds.Energy, Name = "Energy" },
                new SpecCategory { Id = SpecCategoryIds.Charging, Name = "Charging" },
                new SpecCategory { Id = SpecCategoryIds.Practicality, Name = "Practicality" },
            ];
    }
}
