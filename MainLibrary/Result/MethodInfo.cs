using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    public class MethodInfo
    {
        public string Name { get;}
        public string ClassName { get;}
        public double LeadTime { get;}
        public IReadOnlyList<MethodInfo> Methods { get;}

        internal MethodInfo(ChangeableMethodInfo methodInfo)
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
    }
}