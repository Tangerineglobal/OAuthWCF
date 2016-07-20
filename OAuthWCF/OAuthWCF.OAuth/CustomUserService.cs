using IdentityServer3.AspNetIdentity;
using OAuthWCF.OAuth.Asp.Id;

namespace OAuthWCF.OAuth
{
    public class CustomUserService : AspNetIdentityUserService<CustomUser, int>
    {
        public CustomUserService(CustomUserManager userMgr)
            : base(userMgr)
        {
        }
    }
}