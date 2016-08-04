using IdentityServer3.EntityFramework;

namespace OAuthWCF.OAuth.Generators {
    public interface IClientIdGenerator {
        string GenerateClientIdAsync(IClientConfigurationDbContext db);
    }
}
