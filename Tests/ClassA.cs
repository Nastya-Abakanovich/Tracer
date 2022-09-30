using MainLibrary;

namespace Tests
{
    internal class ClassA
    {
        private readonly ITracer _tracer;
        private readonly ClassB _b;

        internal ClassA(ITracer tracer)
        {
            _tracer = tracer;
            _b = new ClassB(_tracer);
        }

        internal void M0()
        {
            _tracer.StartTrace();
            M1();
            _b.M1();
            Thread.Sleep(50);
            _tracer.StopTrace();
        }

        internal void M1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            M2();
            _tracer.StopTrace();
        }

        internal void M2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
