using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class UserSeed
    {
        public static List<User> GetUsers()
        {
            return
            [
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    FullName = "Saigon Auto Hub Manager",
                    Email = "sgh.manager@example.com",
                    Role = UserRole.DealerManager,
                    PasswordHash = "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K", // manager123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    FullName = "Saigon Auto Hub Staff",
                    Email = "sgh.staff@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    FullName = "Hanoi EV Center Manager",
                    Email = "hanoi.manager@example.com",
                    Role = UserRole.DealerManager,
                    PasswordHash = "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K", // manager123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    FullName = "Hanoi EV Center Staff",
                    Email = "hanoi.staff@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000011"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    FullName = "Da Nang Green Motors Manager",
                    Email = "danang.manager@example.com",
                    Role = UserRole.DealerManager,
                    PasswordHash = "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K", // manager123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000012"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    FullName = "Da Nang Green Motors Staff",
                    Email = "danang.staff@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    FullName = "Admin User",
                    Email = "admin@example.com",
                    Role = UserRole.Admin,
                    PasswordHash = "$2a$11$nAccBp1/4t.CxdEBKLXSp.cM3DcozB5b.itLdNwAYPYx/El1ENIdW", // admin123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Manager User",
                    Email = "dealermanager@example.com",
                    Role = UserRole.DealerManager,
                    PasswordHash = "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K", // manager123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Staff User",
                    Email = "dealerstaff@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Staff User 2",
                    Email = "dealerstaff2@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Staff User 3",
                    Email = "dealerstaff3@example.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    FullName = "EVM Staff User",
                    Email = "evmstaff@example.com",
                    Role = UserRole.EvmStaff,
                    PasswordHash = "$2a$11$RQaQvAyAEnDiAved/V5wzOQGwKG3CTmDiWa7uxTBlvR2IUUZ06pWm", // evm123
                },
            ];
        }
    }
}
