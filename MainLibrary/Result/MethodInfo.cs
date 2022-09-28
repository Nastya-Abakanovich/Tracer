using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MainLibrary.Result
{
    public class MethodInfo
    {
        [JsonPropertyName("name")]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonPropertyName("class")]
        [XmlAttribute(AttributeName = "class")]
        public string ClassName { get; set; }

        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public double LeadTime { get; set; }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods { get; set; }

        public MethodInfo(MethodInfo _MethodInfo)
        {
            Name = _MethodInfo.Name;
            ClassName = _MethodInfo.ClassName;
            LeadTime = _MethodInfo.LeadTime;
            Methods = new List<MethodInfo>();
        }

        public MethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
            Methods = new List<MethodInfo>();
        }
    }
}