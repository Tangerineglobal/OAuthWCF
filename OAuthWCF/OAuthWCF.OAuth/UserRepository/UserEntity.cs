using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuthWCF.OAuth.UserRepository
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientCredential { get; set; }
    }
}