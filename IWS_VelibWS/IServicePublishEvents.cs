using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IWS_VelibWS
{
    [ServiceContract]
    public interface IServicePublishEvents
    {
        [OperationContract(IsOneWay = true)]
        void NumberBikesHasChanged(Station station, Contract contract, string result);
    }
}
