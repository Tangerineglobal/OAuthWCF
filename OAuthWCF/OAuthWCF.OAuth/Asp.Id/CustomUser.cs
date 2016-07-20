using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
    }
}