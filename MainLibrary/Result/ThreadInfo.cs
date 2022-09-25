using System.Xml.Serialization;

namespace MainLibrary.Result
{
    public class ThreadInfo
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id;

        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods;

        [XmlAttribute(AttributeName = "time")]
        public double LeadTime
        {
            get
            {
                double time = 0;
                foreach(MethodInfo method in Methods)
                {
                    time += method.LeadTime;
                }
                return time;
            }
            set { }
        }

        public ThreadInfo()
        {
            Methods = new List<MethodInfo>();
        }

        public ThreadInfo(int id)
        {
            Id = id;
            Methods = new List<MethodInfo>();
        }
    }
}
