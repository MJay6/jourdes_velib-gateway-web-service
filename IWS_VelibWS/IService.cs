using System;
using System.ServiceModel;

namespace IWS_VelibWS
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        String GetInfoAbout(string station);
    }
}
