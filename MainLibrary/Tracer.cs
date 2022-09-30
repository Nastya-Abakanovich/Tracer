using System.Diagnostics;
using MainLibrary.ChangeableResult;
using MainLibrary.Result;

namespace MainLibrary
{
    public class Tracer : ITracer
    {
        private ChangeableTraceResult _changeableTraceResult;
        private Stack<StackMethodInfo> _methodOrder;

        public Tracer()
        {
            _changeableTraceResult = new ChangeableTraceResult();
            _methodOrder = new Stack<StackMethodInfo>();
        }

        private ChangeableThreadInfo GetThreadId()
        {
            ChangeableThreadInfo currThreadInfo;
            int currId = Thread.CurrentThread.ManagedThreadId;
            currThreadInfo = _changeableTraceResult.Threads.Find(x => (x.Id == currId));
            if (currThreadInfo == null)
            {
                _changeableTraceResult?.Threads.Add(new ChangeableThreadInfo(currId));
                currThreadInfo = _changeableTraceResult?.Threads[_changeableTraceResult.Threads.Count - 1];
            }
            return currThreadInfo;
        }

        public void StartTrace()
        {
            ChangeableMethodInfo currMethodInfo = new ChangeableMethodInfo();
            StackTrace stackTrace = new StackTrace();
            currMethodInfo.Name = stackTrace.GetFrame(1).GetMethod().Name;
            currMethodInfo.ClassName = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            currMethodInfo.LeadTime = -1;

            StackMethodInfo stackMethod = new StackMethodInfo(
                             Thread.CurrentThread.ManagedThreadId,
                             new Stopwatch(),
                             currMethodInfo
                             );

            _methodOrder.Push(stackMethod);

            stackMethod.MethodStopwatch.Start();    
        }


        public void StopTrace()
        {
            StackMethodInfo parentStackMethodInfo;
            StackMethodInfo currStackMethodInfo = _methodOrder.Pop();

            currStackMethodInfo.MethodStopwatch?.Stop();
            currStackMethodInfo.Method.LeadTime = currStackMethodInfo.MethodStopwatch.Elapsed.TotalMilliseconds;

            if (_methodOrder.Count != 0)
            {
                parentStackMethodInfo = _methodOrder.Pop();
                parentStackMethodInfo.Method.Methods.Add(currStackMethodInfo.Method);
                _methodOrder.Push(parentStackMethodInfo);
            }
            else
            {
                GetThreadId().Methods.Add(currStackMethodInfo.Method);
            }

        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(_changeableTraceResult);
        }
    }
}