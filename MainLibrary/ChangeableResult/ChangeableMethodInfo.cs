using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MainLibrary.Result;

namespace MainLibrary.ChangeableResult
{
    public class ChangeableMethodInfo
    {
        public string Name { get; set; }

        public string ClassName { get; set; }

        public double LeadTime { get; set; }

        public List<ChangeableMethodInfo> Methods { get; set; }

        //public ChangeableMethodInfo(string name, string className, double leadTime, List<ChangeableMethodInfo> methods)
        //{
        //    Name = name;
        //    ClassName = className;
        //    LeadTime = leadTime;
        //    Methods = methods;
        //}

        public ChangeableMethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
            Methods = new List<ChangeableMethodInfo>();
        }

        public ChangeableMethodInfo(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ClassName = methodInfo.ClassName;
            LeadTime = methodInfo.LeadTime;

            List<ChangeableMethodInfo> methods = new List<ChangeableMethodInfo>();

            foreach (MethodInfo method in methodInfo.Methods)
            {
                methods.Add(new ChangeableMethodInfo(method));
            }
            Methods = methods;

        }
    }
}