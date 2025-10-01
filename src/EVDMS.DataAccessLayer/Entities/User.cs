using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public Guid? DealerId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiresAt { get; set; }
        public bool IsActive { get; set; }

        public Dealer? Dealer { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<AuditLog> AuditLogs { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
    }
}
