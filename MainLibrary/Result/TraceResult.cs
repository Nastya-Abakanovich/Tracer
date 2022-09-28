using System.Xml.Serialization;
using System.Text.Json.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        [XmlElement(ElementName = "thread")]
        public IReadOnlyList<ThreadInfo> Threads { get; }

        public TraceResult(ChangeableTraceResult result)
        {
            List<ThreadInfo>  threads = new List<ThreadInfo>();

            foreach(ChangeableThreadInfo thread in result.Threads)
            {
                threads.Add(new ThreadInfo(thread));
            }
            Threads = threads;
        }

        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }

    }
}
