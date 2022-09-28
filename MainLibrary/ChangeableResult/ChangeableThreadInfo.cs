using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.Result;

namespace MainLibrary.ChangeableResult
{
    public class ChangeableThreadInfo
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
                foreach(ChangeableMethodInfo method in Methods)
                {
                    time += method.LeadTime;
                }
                return time;
            }
            set { }
        }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public List<ChangeableMethodInfo> Methods { get; set; }

        public ChangeableThreadInfo()
        {
            Methods = new List<ChangeableMethodInfo>();
        }

        public ChangeableThreadInfo(int id)
        {
            Id = id;
            Methods = new List<ChangeableMethodInfo>();
        }

        public ChangeableThreadInfo(ThreadInfo thread)
        {
            Id = thread.Id;
            LeadTime = thread.LeadTime;

            List<ChangeableMethodInfo> methods = new List<ChangeableMethodInfo>();

            foreach (MethodInfo method in thread.Methods)
            {
                methods.Add(new ChangeableMethodInfo(method));
            }
            Methods = methods;
        }

    }
}
