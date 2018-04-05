using ClientConsole.ServicePublishReference;
using System;

namespace ClientConsole
{
    class ServicePublishCallbackSink : IServicePublishCallback
    {
        public void NumberBikesHasChanged(Station station, Contract contract, string result)
        {
            Console.WriteLine(result);
        }
    }
}
