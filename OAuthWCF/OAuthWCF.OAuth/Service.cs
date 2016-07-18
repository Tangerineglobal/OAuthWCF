using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;

namespace OAuthWCF.OAuth
{
    public class Service
    {
        public string GetEmail()
        {
            var bc =
                ClaimsPrincipal.Current.Identities.First().BootstrapContext as BootstrapContext;
            if (bc != null)
            {
                var jwt = bc.SecurityToken as JwtSecurityToken;
                if (jwt != null)
                {
                    //Checks jwt.Claims for email and if it exists returns email value
                    var claims = jwt.Claims;
                    var email = claims.First(c => c.Type == "email");
                    return email.Value ?? string.Empty;
                }
                return string.Empty;
            }
            return string.Empty;
        }
    }
}