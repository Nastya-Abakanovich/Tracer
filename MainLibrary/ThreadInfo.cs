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
        public List<MethodInfo> Methods;

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
