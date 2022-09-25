using System;
using System.Collections.Generic;
using System.Diagnostics;
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
      //  public Stopwatch MethodStopwatch;
        public List<MethodInfo> Methods;

        public MethodInfo(MethodInfo _MethodInfo)
        {
            Name = _MethodInfo.Name;
            ClassName = _MethodInfo.ClassName;
            LeadTime = _MethodInfo.LeadTime;
         //   MethodStopwatch = new Stopwatch();
            Methods = new List<MethodInfo>();
        }

        public MethodInfo()
        {
            Name = "";
            ClassName = "";
            LeadTime = -1;
          //  MethodStopwatch = new Stopwatch();
            Methods = new List<MethodInfo>();
        }
    }
}