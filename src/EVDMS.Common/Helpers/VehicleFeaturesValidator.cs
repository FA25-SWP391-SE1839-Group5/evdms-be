namespace EVDMS.Common.Helpers
{
    public static class VehicleFeaturesValidator
    {
        public static bool IsValid(VehicleFeatures features, out string error)
        {
            if (
                features.Safety != null
                && features.Safety.Any(f => !FeatureCategoryRules.Safety.Contains(f))
            )
            {
                error = "Invalid feature in Safety category.";
                return false;
            }
            if (
                features.Convenience != null
                && features.Convenience.Any(f => !FeatureCategoryRules.Convenience.Contains(f))
            )
            {
                error = "Invalid feature in Convenience category.";
                return false;
            }
            if (
                features.Entertainment != null
                && features.Entertainment.Any(f => !FeatureCategoryRules.Entertainment.Contains(f))
            )
            {
                error = "Invalid feature in Entertainment category.";
                return false;
            }
            if (
                features.Exterior != null
                && features.Exterior.Any(f => !FeatureCategoryRules.Exterior.Contains(f))
            )
            {
                error = "Invalid feature in Exterior category.";
                return false;
            }
            if (
                features.Seating != null
                && features.Seating.Any(f => !FeatureCategoryRules.Seating.Contains(f))
            )
            {
                error = "Invalid feature in Seating category.";
                return false;
            }
            error = null;
            return true;
        }
    }
}
