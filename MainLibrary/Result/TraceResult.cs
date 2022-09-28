using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace MainLibrary.Result
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        [XmlElement(ElementName = "thread")]
        public List<ThreadInfo> Threads;

        
        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }
    }
}
