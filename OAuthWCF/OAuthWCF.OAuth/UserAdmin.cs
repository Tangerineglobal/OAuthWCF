using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using OAuthWCF.OAuth.Asp.Id;
using Claim = System.Security.Claims.Claim;
using ClaimTypes = System.Security.Claims.ClaimTypes;

namespace OAuthWCF.OAuth
{
    public class UserAdmin
    {
        public async Task<string> RegisterUser(string name, string role, string emailaddress)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, emailaddress),
                new Claim(ClaimTypes.Role, role)
            };
            var connString = ConfigurationManager.ConnectionStrings["SocialNetwork.Idsvr"].ConnectionString;
            var ctx = new CustomContext(connString);
            var store = new CustomUserStore(ctx);
            var mgr = new CustomUserManager(store);
            var service = new CustomUserService(mgr);
            var localctx = new LocalAuthenticationContext()
            {
                UserName = name
            };
            var client = Clients.Get().First();
            var profilectx = new ProfileDataRequestContext()
            {
                IssuedClaims = claims,
                Subject = ClaimsPrincipal.Current,
                Client = client
            };

            

            await service.AuthenticateLocalAsync(localctx);
            await service.GetProfileDataAsync(profilectx);

            var user = ClaimsPrincipal.Current;
            var token = user.FindFirst("access_token").Value;

            var signoutctx = new SignOutContext()
            {
                ClientId = client.ClientId,
                Subject = ClaimsPrincipal.Current
            };

            await service.SignOutAsync(signoutctx);

            return token;
        }
    }
}