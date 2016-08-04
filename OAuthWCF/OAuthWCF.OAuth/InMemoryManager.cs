using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;

namespace OAuthWCF.OAuth
{
    public class InMemoryManager
    {
        

        public IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                new Scope
                {
                    Name = "TokenIssuer",
                    DisplayName = "Token Issuer",
                    Required = false,
                    Type = ScopeType.Resource
                },
                new Scope
                {
                    Name = "AppUser",
                    DisplayName = "App User",
                    Required = false,
                    Type = ScopeType.Resource
                }
            };
        }

        public IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "ClientCredentials",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "Client Credentials",
                    Flow = Flows.ClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true,
                    Claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,"name"),
                        new Claim(ClaimTypes.Role,"role"),
                        new Claim(ClaimTypes.Email,"email")
                    },
                }
            };
        }
    }
}