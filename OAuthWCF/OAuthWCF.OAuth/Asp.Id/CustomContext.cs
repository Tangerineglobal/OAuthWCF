using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomContext :
        IdentityDbContext<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomContext(string connString)
            : base(connString)
        {
        }
    }
}