using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace MainLibrary.Result
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        [XmlElement(ElementName = "thread")]
        public List<ThreadInfo> Threads { get; set; } = new List<ThreadInfo>();


        //public TraceResult()
        //{
        //    Threads = new List<ThreadInfo>();
        //}

        //public TraceResult(TraceResult result)
        //{
        //    Threads = new List<ThreadInfo>();

        //    foreach (var thread in result.Threads)
        //    {
        //        Threads.Add(thread);
        //    }
        //}
    }
}
