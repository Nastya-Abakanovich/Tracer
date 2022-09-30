using MainLibrary;

namespace ExampleOfUse
{
    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(150);
            _bar.InnerMethod();

            _tracer.StopTrace();
        }
    }
}
