using System.ComponentModel.DataAnnotations.Schema;
using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class UserToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string TokenHash { get; set; }
        public UserTokenPurpose Purpose { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }

        public User User { get; set; } = null!;
    }
}
