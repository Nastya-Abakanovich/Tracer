using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.Result;

namespace MainLibrary.ChangeableResult
{
    public class ChangeableMethodInfo
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
        public List<ChangeableMethodInfo> Methods { get; set; }

        public ChangeableMethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
            Methods = new List<ChangeableMethodInfo>();
        }

        internal ChangeableMethodInfo(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ClassName = methodInfo.ClassName;
            LeadTime = methodInfo.LeadTime;

            Methods = new List<ChangeableMethodInfo>();
            foreach (MethodInfo method in methodInfo.Methods)
            {
                Methods.Add(new ChangeableMethodInfo(method));
            }
        }
    }
}