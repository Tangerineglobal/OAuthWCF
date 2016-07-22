using System;
using System.Security.Permissions;

namespace OAuthWCF.Service
{
    class UserAdmin : IUserAdmin
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "TokenIssuer", Authenticated = true)]
        public string RegisterUser(string name, string role, string emailaddress)
        {
            var admin = new OAuthWCF.OAuth.UserAdmin();
            return string.Empty;//admin.RegisterUser(name, role, emailaddress);
        }
    }
}