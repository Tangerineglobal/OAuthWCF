using IdentityManager.AspNetIdentity;
using OAuthWCF.OAuth.Asp.Id;

namespace OAuthWCF.OAuth.IdMgr
{
    public class CustomIdentityManagerService : AspNetIdentityManagerService<CustomUser, int, CustomRole, int>
    {
        public CustomIdentityManagerService(CustomUserManager userMgr, CustomRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {
        }
    }
}