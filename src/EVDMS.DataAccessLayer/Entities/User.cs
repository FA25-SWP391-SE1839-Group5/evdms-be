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
        public bool IsEmailVerified { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

        public Role Role { get; set; } = null!;
        public Dealer? Dealer { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<UserToken> UserTokens { get; set; } = [];
    }
}
