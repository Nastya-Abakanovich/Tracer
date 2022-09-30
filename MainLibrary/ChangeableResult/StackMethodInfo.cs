using System.Diagnostics;

namespace MainLibrary.ChangeableResult
{
    internal class StackMethodInfo
    {
        internal ChangeableMethodInfo Method;
        internal Stopwatch MethodStopwatch;

        internal StackMethodInfo(Stopwatch methodStopwatch, ChangeableMethodInfo method)
        {
            Method = method;
            MethodStopwatch = methodStopwatch;
        }
    }

}
