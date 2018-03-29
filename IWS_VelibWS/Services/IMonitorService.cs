using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IWS_VelibWS
{
    [ServiceContract]
    public interface IMonitorService
    {
        [OperationContract]
        int GetNbRequest();

        [OperationContract]
        int GetNbCacheRequest();

        [OperationContract]
        int GetCacheExpirationTime();

        [OperationContract]
        int SetCacheExpirationTime(int seconds);

        [OperationContract]
        string[] GetCachedCities();
    }
}
