using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EventsLibHost
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            try
            {
                ServiceHost host = new ServiceHost(typeof(EventsLib.CalcService));
                host.Open();
                Console.WriteLine("Service is Hosted as http://localhost:9011/CalcService");
                Console.WriteLine("\nPress  key to stop the service.");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception eX)
            {
                Console.WriteLine("There was en error while Hosting Service [" + eX.Message + "]");
                Console.WriteLine("\nPress  key to close.");
                Console.ReadLine();
            }**/

            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:9011/ServicePublish");
            //Create ServiceHost
            ServiceHost host
            = new ServiceHost(typeof(IWS_VelibWS.ServicePublish), httpUrl);
            //Add a service endpoint
            host.AddServiceEndpoint(typeof(IWS_VelibWS.IServicePublish)
            , new WSDualHttpBinding(), "");
            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            ServiceDebugBehavior sdb = new ServiceDebugBehavior();
            sdb.IncludeExceptionDetailInFaults = true;
            host.Description.Behaviors.Remove(sdb.GetType());
            host.Description.Behaviors.Add(smb);
            host.Description.Behaviors.Add(sdb);
            //Start the Service
            host.Open();

            //Create a URI to serve as the base address
            Uri mexHttpUrl = new Uri("http://localhost:9011/ServicePublish/mex");
            //Create ServiceHost
            ServiceHost mex
            = new ServiceHost(typeof(MetadataExchangeBindings), mexHttpUrl);

            mex.Description.Behaviors.Add(smb);
            //Add a service endpoint
            mex.AddServiceEndpoint(typeof(IMetadataExchange)
            , new WSDualHttpBinding(), "");

            //Start the Service
            mex.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}
