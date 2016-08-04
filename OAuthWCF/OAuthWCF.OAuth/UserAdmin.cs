using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;
using OAuthWCF.OAuth.Generators;

namespace OAuthWCF.OAuth
{
    public class UserAdmin
    {
        public string RegisterUser(string name, string role, string emailaddress)
        {
            var clientIdGenerator = new ClientIdGenerator();
            var clientSecretGenerator = new ClientSecretGenerator();
            var repository = new ClientRepository.ClientRepository();
            var connectionString = ConfigurationManager.ConnectionStrings["OAuthWCF.IdSrv"].ConnectionString;
            var options = new EntityFrameworkServiceOptions {ConnectionString = connectionString};
            IClientConfigurationDbContext clientdb = new ClientConfigurationDbContext
            {
                Database =
                {
                    Connection =
                    {
                        ConnectionString = connectionString
                    }
                }
            };

            var clients =  new[]
            {
                new Client
                {
                    ClientId = clientIdGenerator.GenerateClientIdAsync(clientdb),
                    ClientSecrets = new List<Secret>
                    {
                        clientSecretGenerator.GenerateSecret(clientdb)
                    },
                    ClientName = name,
                    Flow = Flows.ClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        role
                    },
                    Enabled = true,
                    Claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,name),
                        new Claim(ClaimTypes.Role,role),
                        new Claim(ClaimTypes.Email,emailaddress)
                    },
                    AllowClientCredentialsOnly = true
                }
            };
            
            
           repository.Add(clients,options);

            return string.Join(".", clients.First().ClientId, clients.First().ClientSecrets.First());
        }
    }
}