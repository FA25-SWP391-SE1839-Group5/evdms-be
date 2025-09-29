using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class UserSeed
    {
        public static List<User> GetUsers() =>
            [
                new User
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    FullName = "Admin User",
                    Email = "admin@email.com",
                    Role = UserRole.Admin,
                    PasswordHash = "$2a$11$nAccBp1/4t.CxdEBKLXSp.cM3DcozB5b.itLdNwAYPYx/El1ENIdW", // admin123
                },
                new User
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Manager User",
                    Email = "dealermanager@email.com",
                    Role = UserRole.DealerManager,
                    PasswordHash = "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K", // manager123
                },
                new User
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    FullName = "Dealer Staff User",
                    Email = "dealerstaff@email.com",
                    Role = UserRole.DealerStaff,
                    PasswordHash = "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq", // staff123
                },
                new User
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    FullName = "EVM Staff User",
                    Email = "evmstaff@email.com",
                    Role = UserRole.EvmStaff,
                    PasswordHash = "$2a$11$RQaQvAyAEnDiAved/V5wzOQGwKG3CTmDiWa7uxTBlvR2IUUZ06pWm", // evm123
                },
            ];
    }
}
