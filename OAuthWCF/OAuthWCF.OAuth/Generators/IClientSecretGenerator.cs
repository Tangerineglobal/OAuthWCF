using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;

namespace OAuthWCF.OAuth.Generators {
    public interface IClientSecretGenerator {
        Secret GenerateSecret(IClientConfigurationDbContext db);
    }
}