using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace IWS_VelibWS
{
    public class Service : IService
    {
        public List<string> GetCities()
        {
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/contracts?apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            Contract[] contracts = JsonConvert.DeserializeObject<Contract[]>(responseFromServer);
            List<string> output = new List<string>();
            foreach (Contract contract in contracts)
            {
                output.Add(contract.name + ", " + contract.country_code);
            }

            return output;
        }

        public string GetInfoAbout(string stationName, string cityName)
        {
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            Station[] stations = JsonConvert.DeserializeObject<Station[]>(responseFromServer);
            StringBuilder output = new StringBuilder();
            
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

        public List<string> GetStations(string cityName)
        {
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            Station[] stations = JsonConvert.DeserializeObject<Station[]>(responseFromServer);
            List<string> output = new List<string>();
            foreach (Station station in stations)
            {
                output.Add(station.name + "\n" + station.address);
            }

            return output;
        }
    }
}
