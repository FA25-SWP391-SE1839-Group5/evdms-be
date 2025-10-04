using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrder : BaseEntity
    {
        public Guid DealerId { get; set; }
        public Guid VariantId { get; set; }
        public int Quantity { get; set; }
        public VehicleColor Color { get; set; }
        public DealerOrderStatus Status { get; set; }

        public Dealer Dealer { get; set; } = null!;
        public VehicleVariant VehicleVariant { get; set; } = null!;

        public static readonly string[] SearchableColumns = ["Quantity", "Color", "Status"];
    }
}
