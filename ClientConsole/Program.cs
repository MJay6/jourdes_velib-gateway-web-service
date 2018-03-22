using System;
using System.Collections.Generic;
using ClientConsole.ServiceReference;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentSelectedCity = "";
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
                    currentSelectedCity = selectCity(input.Split(' ')[1], currentSelectedCity);
                }
                else if (input.ToLower().StartsWith("station "))
                {
                    selectStation(input.Split(' ')[1], currentSelectedCity);
                }

            }

        }

        private static void selectStation(string input, string currentSelectedCity)
        {
            ServiceClient intermediaryWebService = new ServiceClient();
            bool found = false;
            if (currentSelectedCity.Equals(""))
            {
                Console.WriteLine("Vous n'avez pas sélectionné de ville");
                return;
            }
            Station[] stations = intermediaryWebService.GetStations(currentSelectedCity);
            foreach (Station station in stations)
            {
                if (station.name.ToLower().Contains(input.ToLower()))
                {
                    Console.WriteLine(station.name + "\n");
                    Console.WriteLine(station.name.Split('\n')[0]);
                    Console.WriteLine(currentSelectedCity);
                    Console.ReadLine();
                    Console.Write(intermediaryWebService.GetInfoAbout(station.name.Split('\n')[0], currentSelectedCity));
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Aucune station trouvée pour : " + input);
            }
        }

        private static string selectCity(string input, string currentSelectedCity)
        {
            ServiceClient intermediaryWebService = new ServiceClient();
            bool found = false;
            string selectedCity = currentSelectedCity;
            Contract[] cities = intermediaryWebService.GetCities();

            foreach (Contract city in cities)
            {
                if (city.name.ToLower().Contains(input.ToLower()))
                {
                    Console.WriteLine(city.name + " sélectionné.");
                    selectedCity = city.name.Split(',')[0];
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Aucune ville trouvée pour : " + input);
                Console.WriteLine("Ville actuellement sélectionnée : " + currentSelectedCity);
            }
            return selectedCity;
        }
    }
}
