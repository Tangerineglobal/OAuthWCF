using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAuthWCF.OAuth;
using Thinktecture.IdentityModel.WebApi;

namespace OAuthWCF.Api.Controllers
{
    public class UserAdminController : ApiController
    {
        [ScopeAuthorize(new[] {"TokenUser"})]
        public string RegisterUser([FromBody] string name, [FromBody] string role, [FromBody] string emailaddress)
        {
            var useradmin = new UserAdmin();
            return useradmin.RegisterUser(name, role, emailaddress);
        }
    }
}