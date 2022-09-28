using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MainLibrary.Result
{
    public class ThreadInfo
    {
        [JsonPropertyName("id")]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public double LeadTime
        {
            get
            {
                double time = 0;
                foreach(MethodInfo method in Methods)
                {
                    time += method.LeadTime;
                }
                return time;
            }
            set { }
        }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods { get; set; }

        public ThreadInfo()
        {
            Methods = new List<MethodInfo>();
        }

        public ThreadInfo(int id)
        {
            Id = id;
            Methods = new List<MethodInfo>();
        }

    }
}
