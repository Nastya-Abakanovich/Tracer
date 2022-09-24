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
        public TimeSpan LeadTime;
        public List<MethodInfo> Methods;
    }
}