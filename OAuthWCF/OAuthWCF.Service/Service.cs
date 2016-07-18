using System;
using System.Security.Permissions;
using OAuthWCF.OAuth;

namespace OAuthWCF.Service
{
    public class Service : IService
    {

        [PrincipalPermission(SecurityAction.Demand,Role = "AppUser, TokenIssuer", Authenticated = true)]
        public string GetEmail()
        {
            var service = new OAuth.Service();
            return service.GetEmail();
        }
    }
}