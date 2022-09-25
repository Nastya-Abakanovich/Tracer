using System.Xml.Serialization;
namespace MainLibrary.Result
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [XmlElement(ElementName = "thread")]
        public List<ThreadInfo> Threads;

        
        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }
    }
}
