using System;
using System.Collections.Generic;
// using ClientConsole.ServiceReference;

using ClientConsole.ServicePublishReference;
using System.ServiceModel;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePublishCallbackSink objsink = new ServicePublishCallbackSink();
            InstanceContext instanceContext = new InstanceContext(objsink);
            ServicePublishClient servicePublishClient = new ServicePublishClient(instanceContext);
            servicePublishClient.SubscribeNumberBikesHasChangedEvent();

            string currentSelectedCityName = "";
            ServicePublishReference.Contract currentCity = null;
            Console.WriteLine("Bienvenue sur l'application pour se renseigner sur une station dans le monde !");
            Console.WriteLine("Pour avoir de l'aide tapez 'help'");
            Console.WriteLine("Pour quitter tapez 'exit'");

            while (true)
            {
                var input = Console.ReadLine();
                if ("help".Equals(input))
                {
                    Console.WriteLine("Pour quitter tapez 'exit'");
                    Console.WriteLine("Sélectionnez la ville avec la commande : city [nom]");
                    Console.WriteLine("Récuperez les informations de la station avec la commande : station [nom]");
                    continue;
                }
                else if ("exit".Equals(input))
                {
                    break;
                }
                if (input.ToLower().StartsWith("city "))
                {
                    currentCity = selectCity(input.Split(' ')[1], currentCity);
                    currentSelectedCityName = currentCity.name;
                }
                else if (input.ToLower().StartsWith("station "))
                {
                    if (currentSelectedCityName.Equals(""))
                    {
                        Console.WriteLine("Vous n'avez pas sélectionné de ville");
                        continue;
                    }
                    ServicePublishReference.Station station = selectStation(input.Split(' ')[1], currentSelectedCityName);
                    Console.WriteLine("Station " + station.name);
                    while(true)
                    {
                        // System.Threading.Thread.Sleep(2000);
                        servicePublishClient.GetChangesAboutStation(station, currentCity);
                        Console.ReadLine();
                        break;
                    }
                }
            }

        }

        private static ServicePublishReference.Station selectStation(string input, string currentSelectedCity)
        {
            ServicePublishReference.Station selectedStation = null;
            ServicePublishCallbackSink objsink = new ServicePublishCallbackSink();
            InstanceContext instanceContext = new InstanceContext(objsink);
            ServicePublishClient intermediaryWebService = new ServicePublishClient(instanceContext);

            bool found = false;
            ServicePublishReference.Station[] stations = intermediaryWebService.GetStations(currentSelectedCity);
            foreach (ServicePublishReference.Station station in stations)
            {
                if (station.name.ToLower().Contains(input.ToLower()))
                {
                    Console.WriteLine(station.name + "\n");
                    Console.WriteLine(station.name.Split('\n')[0]);
                    Console.WriteLine(currentSelectedCity);
                    Console.Write(intermediaryWebService.GetInfoAbout(station.name.Split('\n')[0], currentSelectedCity));
                    selectedStation = station;
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Aucune station trouvée pour : " + input);
            }
            return selectedStation;
        }

        private static ServicePublishReference.Contract selectCity(string input, ServicePublishReference.Contract currentSelectedCity)
        {
            ServicePublishCallbackSink objsink = new ServicePublishCallbackSink();
            InstanceContext instanceContext = new InstanceContext(objsink);
            ServicePublishClient intermediaryWebService = new ServicePublishClient(instanceContext);

            bool found = false;
            ServicePublishReference.Contract selectedCity = currentSelectedCity;
            ServicePublishReference.Contract[] cities = intermediaryWebService.GetCities();

            foreach (ServicePublishReference.Contract city in cities)
            {
                if (city.name.ToLower().Contains(input.ToLower()))
                {
                    Console.WriteLine(city.name + " sélectionné.");
                    selectedCity = city;
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Aucune ville trouvée pour : " + input);
                Console.WriteLine("Ville actuellement sélectionnée : " + currentSelectedCity.name);
            }
            return selectedCity;
        }
    }
}
