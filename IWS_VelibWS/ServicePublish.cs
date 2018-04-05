using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IWS_VelibWS
{
    public class ServicePublish : IServicePublish
    {

        public static ObjectCache cache = MemoryCache.Default;
        private Station[] stations;
        public static int nbRequest = 0;
        public static int nbCacheRequest = 0;
        public static int cacheExpirationTime = 10;

        static Action<Station, Contract, string> m_Event1 = delegate { };

        public void SubscribeNumberBikesHasChangedEvent()
        {
            IServicePublishEvents subscriber =
                OperationContext.Current.GetCallbackChannel<IServicePublishEvents>();
            m_Event1 += subscriber.NumberBikesHasChanged;
        }

        public void GetChangesAboutStation(Station station, Contract contract)
        {
            Station result;
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/stations/" + station.number + "?contract=" + contract.name + "&apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            result = JsonConvert.DeserializeObject<Station>(responseFromServer);
            string output;
            if (station.available_bikes != result.available_bikes)
            {
                output = "Changes detected";
            } else
            {
                output = "No changes detected";
            }
            m_Event1(station, contract, output);
        }

        public Contract[] GetCities()
        {
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/contracts?apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            nbRequest++;

            Contract[] contracts = JsonConvert.DeserializeObject<Contract[]>(responseFromServer);

            return contracts;
        }

        public string GetInfoAbout(string stationName, string cityName)
        {
            StringBuilder output = new StringBuilder();
            RefreshStations(cityName);

            foreach (Station station in stations)
            {
                if (station.name.Contains(stationName))
                {
                    output.AppendLine("Nombre de vélos dispo: " + station.available_bikes);
                    output.AppendLine("Emplacements vélo dispo: " + station.available_bike_stands);
                    break;
                }
            }

            return output.ToString();
        }

        public Station[] GetStations(string cityName)
        {
            RefreshStations(cityName);

            return stations;
        }

        public void RefreshStations(string cityName)
        {
            if (!cache.Contains(cityName))
            {
                Console.WriteLine("Mise en cache ! ");
                WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
                nbRequest++;

                stations = JsonConvert.DeserializeObject<Station[]>(responseFromServer);

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(cacheExpirationTime);
                CacheItem item = new CacheItem(cityName, stations);
                cache.Add(item, policy);
            }
            else
            {
                Console.WriteLine("Déjà présent dans le cache");
                stations = (Station[])cache.Get(cityName);
                nbCacheRequest++;
            }
        }
    }
}
