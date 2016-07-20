using System.Collections.Generic;
using IdentityServer3.Core.Configuration;
using Claim = System.Security.Claims.Claim;
using ClaimTypes = System.Security.Claims.ClaimTypes;

namespace OAuthWCF.OAuth
{
    public class UserAdmin
    {
        public string RegisterUser(string name, string role, string emailaddress)
        {
            var options = new IdentityServerOptions
            {
                SigningCertificate = Certificate.Load(),
                RequireSsl = true
            };
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, emailaddress),
                new Claim(ClaimTypes.Role, role)
            };


            return string.Empty;
        }
    }
}