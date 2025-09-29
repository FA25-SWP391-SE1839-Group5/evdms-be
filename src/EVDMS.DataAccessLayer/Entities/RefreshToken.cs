using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDMS.DataAccessLayer.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string TokenHash { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }

        public User User { get; set; } = null!;
    }
}
