using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IWS_VelibWS
{
    [ServiceContract(CallbackContract = typeof(IServicePublishEvents))]
    public interface IServicePublish
    {
        [OperationContract]
        void GetChangesAboutStation(Station station, Contract contract);

        [OperationContract]
        void SubscribeNumberBikesHasChangedEvent();

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
