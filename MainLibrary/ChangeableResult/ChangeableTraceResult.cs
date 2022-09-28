using System.Xml.Serialization;
using System.Text.Json.Serialization;
using MainLibrary.Result;

namespace MainLibrary.ChangeableResult
{
    [XmlRoot(ElementName = "root")]
    public class ChangeableTraceResult
    {
        [JsonPropertyName("threads")]
        [XmlElement(ElementName = "thread")]
        public List<ChangeableThreadInfo> Threads { get; set; }

        public ChangeableTraceResult(TraceResult result)
        {
            List<ChangeableThreadInfo> threads = new List<ChangeableThreadInfo>();

            foreach (ThreadInfo thread in result.Threads)
            {
                threads.Add(new ChangeableThreadInfo(thread));
            }
            Threads = threads;
        }

        public ChangeableTraceResult()
        {
            Threads = new List<ChangeableThreadInfo>();
        }
    }
}
