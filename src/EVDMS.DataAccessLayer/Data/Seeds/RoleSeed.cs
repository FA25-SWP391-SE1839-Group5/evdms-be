using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class RoleSeed
    {
        public static List<Role> Roles =>
            [
                new Role { Id = RoleIds.DealerStaff, RoleName = "Dealer Staff" },
                new Role { Id = RoleIds.DealerManager, RoleName = "Dealer Manager" },
                new Role { Id = RoleIds.EvmStaff, RoleName = "EVM Staff" },
                new Role { Id = RoleIds.Admin, RoleName = "Admin" },
            ];
    }
}
