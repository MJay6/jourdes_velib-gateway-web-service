using System;
using IWS_VelibWS;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome on our app to find status of velib stations in Toulouse !");
            Console.WriteLine("You can have more help with the 'help' command");
            Console.WriteLine("You can exit by typing 'exit'");
            while (true)
            {
                Console.WriteLine("\nWhich station are you looking for ?");
                var input = Console.ReadLine();
                if ("help".Equals(input))
                {
                    Console.WriteLine("You can exit by typing 'exit'");
                    Console.WriteLine("Simply type the name of the station");
                    continue;
                } else if ("exit".Equals(input)){
                    break;
                }
                Service intermediaryWebService = new Service();
                Console.Write(intermediaryWebService.GetCities());
            }
            
        }
    }
}
