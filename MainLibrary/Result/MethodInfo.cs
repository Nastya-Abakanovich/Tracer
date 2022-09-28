using System.Xml.Serialization;

namespace MainLibrary.Result
{
    public class MethodInfo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name;

        [XmlAttribute(AttributeName = "class")]
        public string ClassName;

        [XmlAttribute(AttributeName = "time")]
        public double LeadTime;

        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods;

        public MethodInfo(MethodInfo _MethodInfo)
        {
            Name = _MethodInfo.Name;
            ClassName = _MethodInfo.ClassName;
            LeadTime = _MethodInfo.LeadTime;
            Methods = new List<MethodInfo>();
        }

        public MethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
            Methods = new List<MethodInfo>();
        }
    }
}