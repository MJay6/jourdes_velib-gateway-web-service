using System.Runtime.Serialization;

namespace IWS_VelibWS
{
    [DataContract]
    public class Contract
    {
        [DataMember]
        public string name { get; set;}

        [DataMember]
        public string country_code { get; set; }
    }
}
