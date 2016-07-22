using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace OAuthWCF.OAuth
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "MVC OWIN Implicit Client",
                    ClientId = "mvc.owin.implicit",
                    Flow = Flows.Implicit,
                    EnableLocalLogin = true,
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3600,
                    AllowAccessTokensViaBrowser = false,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                    },
                    ClientUri = "https://identityserver.io",
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44301/"
                    },
                    LogoutUri = "https://localhost:44301/Home/SignoutCleanup",
                    LogoutSessionRequired = true,
                },
            };
        }
    }
}