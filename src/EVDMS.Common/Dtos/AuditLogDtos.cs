using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class AuditLogDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AuditLogAction Action { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateAuditLogDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public AuditLogAction Action { get; set; }

        [Required]
        public required string Description { get; set; }
    }

    public class UpdateAuditLogDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public AuditLogAction Action { get; set; }

        [Required]
        public required string Description { get; set; }
    }

    public class PatchAuditLogDto
    {
        public Guid? UserId { get; set; }
        public AuditLogAction? Action { get; set; }
        public string? Description { get; set; }
    }
}
