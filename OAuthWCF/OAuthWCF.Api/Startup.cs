using System;
using System.Threading.Tasks;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;

[assembly: OwinStartup(typeof(OAuthWCF.Api.Startup))]

namespace OAuthWCF.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = "http://localhost:58730/Resources"
            });
        }
    }
}
