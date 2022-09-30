using MainLibrary;

namespace Tests
{
    internal class ClassB
    {
        private readonly ITracer _tracer;

        internal ClassB(ITracer tracer)
        {
            _tracer = tracer;
        }

        internal void M1()
        {
            _tracer.StartTrace();
            Thread.Sleep(150);
            _tracer.StopTrace();
        }
    }
}
