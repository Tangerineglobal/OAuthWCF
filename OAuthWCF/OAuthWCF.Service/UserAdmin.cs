using System;
using System.Security.Permissions;

namespace OAuthWCF.Service
{
    class UserAdmin : IUserAdmin
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "TokenIssuer", Authenticated = true)]
        public string RegisterUser(string name, string role, string emailaddress)
        {
            return $"we're here in registeruser now {DateTime.Now.ToShortDateString()}";
        }
    }
}