using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class MethodInfo
    {
        public string Name;
        public string ClassName;
        public double LeadTime;
        public List<MethodInfo> Methods;

        public MethodInfo(MethodInfo _MethodInfo)
        {
            Name = _MethodInfo.Name;
            ClassName = _MethodInfo.ClassName;
            LeadTime = _MethodInfo.LeadTime;
        }

        public MethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = 0;
        }
    }
}