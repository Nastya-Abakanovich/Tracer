using System.Collections.Concurrent;
using System.Diagnostics;
using MainLibrary.ChangeableResult;
using MainLibrary.Result;

namespace MainLibrary
{
    public class Tracer : ITracer
    {
        private ChangeableTraceResult _changeableTraceResult;
        private ConcurrentDictionary<int, ConcurrentStack<StackMethodInfo>> _methodOrder;
        private object locker = new();

        public Tracer()
        {
            _changeableTraceResult = new ChangeableTraceResult();
            _methodOrder = new ConcurrentDictionary<int, ConcurrentStack<StackMethodInfo>>();
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

            int threadId = Thread.CurrentThread.ManagedThreadId;
            _methodOrder.TryAdd(threadId, new ConcurrentStack<StackMethodInfo>());
            _methodOrder[threadId].Push(stackMethod);

            stackMethod.MethodStopwatch.Start();    
        }


        public void StopTrace()
        {
            StackMethodInfo parentStackMethodInfo; 
            StackMethodInfo currStackMethodInfo;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            _methodOrder[threadId].TryPop(out currStackMethodInfo);

            currStackMethodInfo.MethodStopwatch?.Stop();
            currStackMethodInfo.Method.LeadTime = currStackMethodInfo.MethodStopwatch.Elapsed.TotalMilliseconds;

            if (_methodOrder[threadId].TryPop(out parentStackMethodInfo))
            {
                parentStackMethodInfo.Method.Methods.Add(currStackMethodInfo.Method);
                _methodOrder[threadId].Push(parentStackMethodInfo);
            }
            else
            {
                lock (locker)
                {
                    GetThreadId().Methods.Add(currStackMethodInfo.Method);
                }
            }

        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(_changeableTraceResult);
        }
    }
}