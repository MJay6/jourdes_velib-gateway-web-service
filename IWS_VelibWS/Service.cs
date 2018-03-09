using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace IWS_VelibWS
{
    public class Service : IService
    {

        public string GetInfoAbout(string input)
        {
            WebRequest request = WebRequest.Create(
                    "https://api.jcdecaux.com/vls/v1/stations?contract=Toulouse&apiKey=435c32acbb8ca694cedbf15f5181e66ca560de1a");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            Station[] stations = JsonConvert.DeserializeObject<Station[]>(responseFromServer);
            StringBuilder output = new StringBuilder();

            bool found = false;
            foreach (Station station in stations)
            {
                if (station.name.ToLower().Contains(input.ToLower()))
                {
                    found = true;
                    output.AppendLine("Station: " + station.name);
                    output.AppendLine("Nombre de vélos dispo: " + station.available_bikes);
                    output.AppendLine("Emplacements vélo dispo: " + station.available_bike_stands);
                    break;
                }
            }
            if (!found)
            {
                output.AppendLine("Sorry, we didn't find any match... Try again");
            }

            return output.ToString();
        }
    }
}
