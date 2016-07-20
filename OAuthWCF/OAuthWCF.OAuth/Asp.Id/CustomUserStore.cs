using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomUserStore :
        UserStore<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(CustomContext ctx)
            : base(ctx)
        {
        }
    }
}