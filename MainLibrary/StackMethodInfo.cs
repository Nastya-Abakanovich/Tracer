﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    internal class StackMethodInfo
    {
        internal MethodInfo Method;
        internal Stopwatch MethodStopwatch;
        internal int ThreadId;

        internal StackMethodInfo(int threadId, Stopwatch methodStopwatch, MethodInfo method)
        {
            ThreadId = threadId;
            Method = method;
            MethodStopwatch = methodStopwatch;
        }
    }

}
