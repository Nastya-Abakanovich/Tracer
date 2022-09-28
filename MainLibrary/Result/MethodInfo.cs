using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    public class MethodInfo
    {
        [JsonPropertyName("name")]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get;}

        [JsonPropertyName("class")]
        [XmlAttribute(AttributeName = "class")]
        public string ClassName { get;}

        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public double LeadTime { get;}

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public IReadOnlyList<MethodInfo> Methods { get;}

        public MethodInfo(ChangeableMethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ClassName = methodInfo.ClassName;
            LeadTime = methodInfo.LeadTime;

            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (ChangeableMethodInfo method in methodInfo.Methods)
            {
                methods.Add(new MethodInfo(method));
            }
            Methods = methods;

        }

        public MethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
           // Methods = new List<MethodInfo>();
        }
    }
}