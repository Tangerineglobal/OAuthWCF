using IdentityManager;
using IdentityManager.Configuration;
using OAuthWCF.OAuth.Asp.Id;

namespace OAuthWCF.OAuth.IdMgr
{
    public static class CustomIdentityManagerServiceExtensions
    {
        public static void ConfigureCustomIdentityManagerServiceWithIntKeys(this IdentityManagerServiceFactory factory,
            string connectionString)
        {
            factory.Register(new Registration<CustomContext>(resolver => new CustomContext(connectionString)));
            factory.Register(new Registration<CustomUserStore>());
            factory.Register(new Registration<CustomRoleStore>());
            factory.Register(new Registration<CustomUserManager>());
            factory.Register(new Registration<CustomRoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, CustomIdentityManagerService>();
        }
    }
}