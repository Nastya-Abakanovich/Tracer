using System.Diagnostics;
using MainLibrary.ChangeableResult;
using MainLibrary.Result;
//using MainLibrary.Serialization;

namespace MainLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult _result;
        private ChangeableTraceResult? _traceResult;
        private Stack<StackMethodInfo> _methodOrder;

        public Tracer()
        {
            _traceResult = new ChangeableTraceResult();
            _methodOrder = new Stack<StackMethodInfo>();
        }

        private ChangeableThreadInfo GetThreadId()
        {
            ChangeableThreadInfo currThreadInfo;
            int currId = Thread.CurrentThread.ManagedThreadId;
            currThreadInfo = _traceResult.Threads.Find(x => (x.Id == currId));
            if (currThreadInfo == null)
            {
                _traceResult?.Threads.Add(new ChangeableThreadInfo(currId));
                currThreadInfo = _traceResult?.Threads[_traceResult.Threads.Count - 1];
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
            currStackMethodInfo.Method.LeadTime = currStackMethodInfo.MethodStopwatch.Elapsed.TotalSeconds;

            if (_methodOrder.TryPop(out parentStackMethodInfo))
            {
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
         //   XmlSerialization ser = new XmlSerialization();
         //   string s = ser.Serialize(_traceResult);
            _result = new TraceResult(_traceResult);
            return _result;
        }
    }
}