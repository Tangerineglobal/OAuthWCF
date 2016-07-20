using Microsoft.AspNet.Identity;

namespace OAuthWCF.OAuth.Asp.Id
{
    public class CustomUserManager : UserManager<CustomUser, int>
    {
        public CustomUserManager(CustomUserStore store)
            : base(store)
        {
        }
    }
}