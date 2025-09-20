using System.Collections.Generic;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Role : BaseEntity
    {
        public required string RoleName { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
