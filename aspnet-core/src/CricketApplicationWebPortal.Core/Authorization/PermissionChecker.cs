using Abp.Authorization;
using CricketApplicationWebPortal.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Users;

namespace CricketApplicationWebPortal.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
