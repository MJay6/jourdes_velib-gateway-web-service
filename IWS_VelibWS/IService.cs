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
        Contract[] GetCities();

        [OperationContract]
        Station[] GetStations(string cityName);

        [OperationContract]
        void RefreshStations(string cityName);

    }
}
