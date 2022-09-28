using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    public class ThreadInfo
    {
        [JsonPropertyName("id")]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get;}

        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public double LeadTime
        {
            get;
        }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public IReadOnlyList<MethodInfo> Methods { get; }

        public ThreadInfo()
        {
          // Methods = new List<MethodInfo>();
        }

        public ThreadInfo(int id)
        {
            Id = id;
            Methods = new List<MethodInfo>();
        }

        public ThreadInfo(ChangeableThreadInfo thread)
        {
            Id = thread.Id;
            LeadTime = thread.LeadTime;

            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (ChangeableMethodInfo method in thread.Methods)
            {
                methods.Add(new MethodInfo(method));
            }
            Methods = methods;
        }

    }
}
