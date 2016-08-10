using System.Web.Http;
using OAuthWCF.OAuth;
using Thinktecture.IdentityModel.WebApi;

namespace OAuthWCF.Api.Controllers
{
    public class UserAdminController : ApiController
    {
        [ScopeAuthorize(new[] {"TokenUser"})]
        public string RegisterUser([FromUri] string name, [FromUri] string role, [FromUri] string emailaddress)
        {
            var useradmin = new UserAdmin();
            return useradmin.RegisterUser(name, role, emailaddress);
        }
    }
}