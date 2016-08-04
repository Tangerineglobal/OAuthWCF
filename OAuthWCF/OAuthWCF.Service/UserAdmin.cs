using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;
using IdentityModel.Client;

namespace OAuthWCF.Service
{
    public class UserAdmin : IUserAdmin
    {
        public string RegisterUser(string name, string role, string emailaddress)
        {
            var clientId = WebOperationContext.Current?.IncomingRequest.UriTemplateMatch.QueryParameters["client_id"];
            var clientSecret =
                WebOperationContext.Current?.IncomingRequest.UriTemplateMatch.QueryParameters["client_secret"];
            var response = RequestToken(clientId, clientSecret);
            return CallService(response.AccessToken, name, role, emailaddress);
        }

        private TokenResponse RequestToken(string clientId, string clientSecret)
        {
            var client = new TokenClient(
                "http://localhost:58730/Connect/Token",
                clientId,
                clientSecret);

            return client.RequestClientCredentialsAsync("AppUser TokenIssuer").Result;
        }

        private string CallService(string token, string name, string role, string emailaddress)
        {
            var baseAddress = "http://localhost:24048/";
            var values = new NameValueCollection
            {
                {"name", name},
                {"role", role},
                {"emailaddress", emailaddress}
            };

            var query = ToQueryString(values);
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
            client.SetBearerToken(token);
            var response = client.GetStringAsync("api/UserAdmin/RegisterUser"+query);
            return response.Result;
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}")
                .ToArray();
            return "?" + string.Join("&", array);
        }
    }
}