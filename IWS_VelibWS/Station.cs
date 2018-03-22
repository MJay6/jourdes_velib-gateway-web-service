using System.Runtime.Serialization;

namespace IWS_VelibWS
{
    [DataContract]
    public class Station
    {
        [DataMember]
        public int number { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public int available_bikes { get; set; }

        [DataMember]
        public int available_bike_stands { get; set; }
    }
}
