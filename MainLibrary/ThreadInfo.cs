using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class ThreadInfo
    {
        public int Id;
        public TimeSpan LeadTime;
        public List<MethodInfo> Methods;
    }
}
