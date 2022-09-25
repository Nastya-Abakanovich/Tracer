using System.Diagnostics;

namespace MainLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult? _traceResult;
        private ThreadInfo _currThreadInfo;
        private Stopwatch _stopwatch;
        private MethodInfo _info;
        private StackTrace _stackTrace;
        private int _currThreadNumber;

        public Tracer()
        {
            if (_traceResult == null)
            {
                _traceResult = new TraceResult();
            }

            _stopwatch = new Stopwatch();
            
        }


        public void StartTrace()
        {
            _stopwatch.Start();

            int currId = Thread.CurrentThread.ManagedThreadId;
            _currThreadInfo = _traceResult.Threads.Find(x => (x.Id == currId));
            if (_currThreadInfo != null)
            {
                _currThreadNumber = _traceResult.Threads.IndexOf(_currThreadInfo);
            }
            else
            {
                _traceResult?.Threads.Add(new ThreadInfo());
                _currThreadNumber = _traceResult.Threads.Count - 1;
                _traceResult.Threads[_currThreadNumber].Id = currId;
            }
        }


        public void StopTrace()
        {
            _stopwatch?.Stop();

            _stackTrace = new StackTrace();
            _info = new MethodInfo();
            _info.Name = _stackTrace.GetFrame(1).GetMethod().Name;
            _info.ClassName = _stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            _info.LeadTime = _stopwatch.Elapsed.TotalSeconds;

            _traceResult.Threads[_currThreadNumber].Methods.Add(_info);
        }

        public TraceResult GetTraceResult()
        {

            return _traceResult;
        }
    }
}