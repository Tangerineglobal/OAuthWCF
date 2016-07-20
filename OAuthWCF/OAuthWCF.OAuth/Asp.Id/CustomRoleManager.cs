using Microsoft.AspNet.Identity;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomRoleManager : RoleManager<CustomRole, int>
    {
        public CustomRoleManager(CustomRoleStore store)
            : base(store)
        {
        }
    }
}