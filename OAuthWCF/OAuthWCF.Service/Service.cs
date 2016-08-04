using System;
using IdentityModel;
using IdentityModel.Client;
using IdentityModel.Extensions;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.ServiceModel.Web;


namespace OAuthWCF.Service
{
    public class Service : IService
    {
        public string GetEmail()
        {
            var clientId = WebOperationContext.Current?.IncomingRequest.UriTemplateMatch.QueryParameters["client_id"];
            var clientSecret = WebOperationContext.Current?.IncomingRequest.UriTemplateMatch.QueryParameters["client_secret"];
            var response = RequestToken(clientId,clientSecret);
            return CallService(response.AccessToken);
        }

        private TokenResponse RequestToken(string clientId,string clientSecret)
        {
            var client = new TokenClient(
                "http://localhost:58730/Connect/Token",
                clientId,
                clientSecret);

            return client.RequestClientCredentialsAsync("AppUser TokenIssuer").Result;
           
        }


        private string CallService(string token)
        {
            var baseAddress = "http://localhost:24048/";

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            client.SetBearerToken(token);
            var response = client.GetStringAsync("api/Service/GetEmail");
            return response.Result;
        }
    }
}