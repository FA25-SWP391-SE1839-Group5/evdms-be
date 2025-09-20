using System.Collections.Generic;

namespace EVDMS.DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid? DealerId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string PasswordHash { get; set; }

        public required Role Role { get; set; }
        public Dealer? Dealer { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
    }
}
