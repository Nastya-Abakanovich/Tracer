using System.Diagnostics;

namespace MainLibrary.ChangeableResult
{
    internal class StackMethodInfo
    {
        internal ChangeableMethodInfo Method;
        internal Stopwatch MethodStopwatch;
        internal int ThreadId;

        internal StackMethodInfo(int threadId, Stopwatch methodStopwatch, ChangeableMethodInfo method)
        {
            ThreadId = threadId;
            Method = method;
            MethodStopwatch = methodStopwatch;
        }
    }

}
