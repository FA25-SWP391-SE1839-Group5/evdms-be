using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Helpers
{
    public class VehicleFeatures
    {
        public List<FeatureType> Safety { get; set; } = [];
        public List<FeatureType> Convenience { get; set; } = [];
        public List<FeatureType> Entertainment { get; set; } = [];
        public List<FeatureType> Exterior { get; set; } = [];
        public List<FeatureType> Seating { get; set; } = [];
    }
}
