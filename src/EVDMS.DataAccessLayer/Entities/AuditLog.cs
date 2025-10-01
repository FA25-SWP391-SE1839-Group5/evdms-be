using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class AuditLog : BaseEntity
    {
        public Guid UserId { get; set; }
        public AuditLogAction Action { get; set; }
        public required string Description { get; set; }

        public User User { get; set; } = null!;

        public static readonly string[] SearchableColumns = ["UserId", "Action", "Description"];
    }
}
