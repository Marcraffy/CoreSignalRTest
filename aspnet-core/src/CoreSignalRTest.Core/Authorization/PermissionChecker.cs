using Abp.Authorization;
using CoreSignalRTest.Authorization.Roles;
using CoreSignalRTest.Authorization.Users;

namespace CoreSignalRTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
