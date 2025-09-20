using System.Collections.Generic;

namespace EVDMS.DataAccessLayer.Entities
{
    public class FeatureCategory : BaseEntity
    {
        public required string CategoryName { get; set; }
        public ICollection<Feature> Features { get; set; } = [];
    }
}