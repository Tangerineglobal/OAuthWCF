using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using OAuthWCF.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace OAuthWCF.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var entityFrameworkOptions = new EntityFrameworkServiceOptions
            {
                ConnectionString =
                    ConfigurationManager.ConnectionStrings["SocialNetwork.Idsvr"].ConnectionString
            };


            var inMemoryManager = new InMemoryManager();
            SetupClients(inMemoryManager.GetClients(), entityFrameworkOptions);
            SetupScopes(inMemoryManager.GetScopes(), entityFrameworkOptions);

            var factory = new IdentityServerServiceFactory();
            factory.RegisterConfigurationServices(entityFrameworkOptions);
            factory.RegisterOperationalServices(entityFrameworkOptions);

            new TokenCleanup(entityFrameworkOptions, 1).Start();


            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                // the endpoint path which will be consumed via HTTP. e.g. http://website[:port]/api/auth

                AuthorizeEndpointPath = new PathString("/api/auth"),
                //Provider is a class which inherits from OAuthAuthorizationServerProvider.Will be covered next.
                Provider = new OAuthAuthorizationServerProvider(),
                // mark true if you are not on https channel
                AllowInsecureHttp = true,
            });
            // indicate our intent to use bearer authentication
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            });


            var options = new IdentityServerOptions
            {
                SigningCertificate = Certificate.Load(), //Provide your X509 Certificate in production environment
                RequireSsl = true,
                Factory = factory
            };

            app.UseIdentityServer(options);
        }


        public void SetupClients(IEnumerable<Client> clients,
            EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ClientConfigurationDbContext(options.ConnectionString,
                    options.Schema))
            {
                if (context.Clients.Any()) return;

                foreach (var client in clients)
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }
        }

        public void SetupScopes(IEnumerable<Scope> scopes,
            EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ScopeConfigurationDbContext(options.ConnectionString,
                    options.Schema))
            {
                if (context.Scopes.Any()) return;

                foreach (var scope in scopes)
                {
                    context.Scopes.Add(scope.ToEntity());
                }

                context.SaveChanges();
            }
        }
    }
}