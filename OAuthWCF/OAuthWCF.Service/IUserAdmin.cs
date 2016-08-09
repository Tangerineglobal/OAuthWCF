using System.ServiceModel;

namespace OAuthWCF.Service
{
    [ServiceContract]
    public interface IUserAdmin
    {
        [OperationContract]
        string RegisterUser(string name, string role, string emailaddress);
    }
}
