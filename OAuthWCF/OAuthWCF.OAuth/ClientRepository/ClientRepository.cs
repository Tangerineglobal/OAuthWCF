using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;
using Client = IdentityServer3.Core.Models.Client;

namespace OAuthWCF.OAuth.ClientRepository
{
    public class ClientRepository
    {
        public void Add(IEnumerable<Client> clients,
            EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ClientConfigurationDbContext(options.ConnectionString))
            {
                if (context.Clients.Any()) return;

                foreach (var client in clients)
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }
        }
        public List<Claim> GetClientClaims(string clientId, string clientSecret,
            EntityFrameworkServiceOptions options)
        {
            var list = new List<Claim>();
            var secret = new Secret(clientSecret);
            using (var context =
                new ClientConfigurationDbContext(options.ConnectionString))
            {
                var client =
                    context.Clients.First(
                        v => v.ClientId == clientId);
                foreach (var clientClaim in client.Claims)
                {
                    list.Add(new Claim(clientClaim.Type, clientClaim.Value));
                }
            }
            return list;
        }
    }
}