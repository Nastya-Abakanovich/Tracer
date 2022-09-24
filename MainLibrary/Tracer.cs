using System.Diagnostics;

namespace MainLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private Stopwatch _stopwatch;
        private MethodInfo _info;
        private StackTrace _stackTrace;

        public Tracer()
        {
            if (_traceResult == null)
                _traceResult = new TraceResult();

            _stopwatch = new Stopwatch();
            _info = new MethodInfo();
        }


        public void StartTrace()
        {
            _stopwatch.Start();
        }


        public void StopTrace()
        {
            _stopwatch?.Stop();

            _stackTrace = new StackTrace();
            _info.Name = _stackTrace.GetFrame(1).GetMethod().Name;
            _info.ClassName = _stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            _info.LeadTime = _stopwatch.Elapsed;

        }

        public TraceResult GetTraceResult()
        {

            return _traceResult;
        }
    }
}