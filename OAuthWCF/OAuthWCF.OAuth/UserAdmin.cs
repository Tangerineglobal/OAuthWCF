using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using System.IdentityModel.Claims;
using BrockAllen.MembershipReboot;
using IdentityServer3.MembershipReboot;
using Owin;
using Claim = System.IdentityModel.Claims.Claim;

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
            var config = new MembershipRebootConfiguration()
            {
                AllowAccountDeletion = true,
                AllowLoginAfterAccountCreation = true,
                Crypto = new DefaultCrypto(),
                EmailIsUsername = false
            };
            //var provider = new MembershipRebootUserService<>();
            //provider.
            return string.Empty;
        }
        
    }
}


//var payload = new JwtPayload(claims);
//var userservice = new InMemoryUserService(new List<InMemoryUser>());//Todo: retrieve inmemoryusers
//var claimsprovider = new DefaultClaimsProvider(userservice);
//var itokenhandlestore = new InMemoryTokenHandleStore();
//var itokensigningservice = new DefaultTokenSigningService(options);
//var events = new DefaultEventService();
//var authocodes = new InMemoryAuthorizationCodeStore();
////public async Task<AuthorizeResponse> CreateResponseAsync(ValidatedAuthorizeRequest request)
//var defaultTokenService = new DefaultTokenService(options, claimsprovider, itokenhandlestore, itokensigningservice, events);
//var authorizationresponsegenerator =
//    new AuthorizeResponseGenerator(
//        tokenService: defaultTokenService,
//        authorizationCodes: authocodes, events: events);
//var request = new ValidatedAuthorizeRequest
//{
//    Flow = Flows.Implicit,
//    ClientId = Base64UrlEncoder.Encode(name),
//    Options = options,
//    ResponseType = Constants.ResponseTypes.IdTokenToken,
//    ResponseMode = Constants.ResponseModes.FormPost
//};
//var authorizationresponse = authorizationresponsegenerator.CreateImplicitFlowResponseAsync(request);
//var token = authorizationresponse.Result.AccessToken;