using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(CustomContext ctx)
            : base(ctx)
        {
        }
    }
}