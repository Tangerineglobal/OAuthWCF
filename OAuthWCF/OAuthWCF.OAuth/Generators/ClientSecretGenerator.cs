using System.Linq;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;

namespace OAuthWCF.OAuth.Generators {
    public class ClientSecretGenerator : IClientSecretGenerator {

        /// <summary>
        /// http://openid.net/specs/openid-connect-registration-1_0.html#RegistrationResponse
        /// The same Client Secret value MUST NOT be assigned to multiple Clients.
        /// </summary>
        /// <returns></returns>
        public  Secret GenerateSecret(IClientConfigurationDbContext db) {
            Secret secret = null;
            bool exists = false;

            do {
                string clientSecretString = RandomStringGenerator.GetRandomString(12);

                secret = new Secret(clientSecretString.Sha256()); // setting for sha version?

                exists =  db.Clients.Any(c => c.ClientSecrets.Any(s => s.Value == secret.Value));
            } while (exists);

            return secret;
        }
    }
}
