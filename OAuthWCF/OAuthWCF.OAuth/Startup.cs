using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.EntityFramework;
using Microsoft.Owin;
using OAuthWCF.OAuth;
using Owin;
//using OAuthWCF.Data;
//using OAuthWCF.Data.Models;
//using OAuthWCF.Data.Repositories;

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
                    ConfigurationManager.ConnectionStrings["OAuthWCF.IdSrv"].ConnectionString
            };

            var inMemoryManager = new InMemoryManager();
            SetupClients(inMemoryManager.GetClients(), entityFrameworkOptions);
            SetupScopes(inMemoryManager.GetScopes(), entityFrameworkOptions);

            //Repositories
            var userRepository =
                new UserRepository.UserRepository(ConfigurationManager.ConnectionStrings["OAuthWCF.Users"].ConnectionString);
            //var claimsRepository =
            //    new ClaimRepository(ConfigurationManager.ConnectionStrings["OAuthWCF.Users"].ConnectionString);


            //Register EntityFramework Options
            var factory = new IdentityServerServiceFactory();
            factory.RegisterConfigurationServices(entityFrameworkOptions);
            factory.RegisterOperationalServices(entityFrameworkOptions);
            factory.UserService = new Registration<IUserService>(
                typeof(UserService));
            //factory.Register(new Registration<IRepository<User>>(userRepository));
            //factory.Register(new Registration<IRepository<Claim>>(claimsRepository));

            new TokenCleanup(entityFrameworkOptions, 1).Start();

            var options = new IdentityServerOptions
            {
                SigningCertificate = Certificate.Get(), //Do not use this certificate. Change it with your own. 
                RequireSsl = false,
                //for testing purposes. Please change it with true when you are going to deploy in production. 
                Factory = factory
            };

            app.UseIdentityServer(options);
        }

        public void SetupClients(IEnumerable<Client> clients,
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

        public void SetupScopes(IEnumerable<Scope> scopes,
            EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ScopeConfigurationDbContext(options.ConnectionString))
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