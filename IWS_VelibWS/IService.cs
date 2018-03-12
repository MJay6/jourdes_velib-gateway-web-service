using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace IWS_VelibWS
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetInfoAbout(string station, string cityName);

        [OperationContract]
        List<string> GetCities();

        [OperationContract]
        List<string> GetStations(string cityName);
    }
}
