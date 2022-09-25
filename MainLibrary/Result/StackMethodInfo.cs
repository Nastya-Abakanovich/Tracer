using System.Diagnostics;

namespace MainLibrary.Result
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
