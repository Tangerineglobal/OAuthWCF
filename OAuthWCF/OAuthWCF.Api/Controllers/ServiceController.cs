using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace OAuthWCF.Api.Controllers
{
    public class ServiceController : ApiController
    {
        [ScopeAuthorize(new [] { "AppUser","TokenUser"})]
        public string GetEmail()
        {
            var principal = User as ClaimsPrincipal;
            return principal != null ? principal.Claims.First(v => v.Type == ClaimTypes.Name).Value : string.Empty;
        }
    }
}