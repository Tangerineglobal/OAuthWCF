using System.ServiceModel;

namespace OAuthWCF.Service
{
    [ServiceContract]
    public interface IService
    {
        
        [OperationContract]
        string GetEmail();
    }
}
