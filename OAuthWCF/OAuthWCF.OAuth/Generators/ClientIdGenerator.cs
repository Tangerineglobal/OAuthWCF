using System.Linq;
using IdentityServer3.EntityFramework;

namespace OAuthWCF.OAuth.Generators {
    public class ClientIdGenerator : IClientIdGenerator {
        public string GenerateClientIdAsync(IClientConfigurationDbContext db) {
            string clientId = null;
            bool exists = false;

            do {
                clientId = RandomStringGenerator.GetRandomString(12);
                exists = db.Clients.Any(c => c.ClientId == clientId);
            } while (exists);

            return clientId;
        }
    }
}
