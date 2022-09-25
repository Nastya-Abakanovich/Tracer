using MainLibrary;
using MainLibrary.Result;

namespace ExampleOfUse
{
    internal class Program
    {
        static private Tracer tr;
        static object locker = new();
        static void Main()
        {
            
            tr = new Tracer();

            Thread myThread1 = new Thread(Meth);
            myThread1.Start();  // запускаем поток myThread1
            Meth();
            myThread1.Join();
            TraceResult trRes = tr.GetTraceResult();
            Console.Read();
        }

        static public void Meth()
        {

                C c = new C(tr);
            lock (locker)
            {
                c.M0();
            }
            
        }
    }

    public class C
    {
        private ITracer _tracer;

        public C(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void M0()
        {
            M1();
            M2();
        }

        private void M1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            M2();
            M3();
            M4();
            Console.WriteLine("M1");
            _tracer.StopTrace();
        }

        private void M2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            Console.WriteLine("M2");
            _tracer.StopTrace();
        }
        private void M3()
        {
            _tracer.StartTrace();
            Thread.Sleep(400);
            Console.WriteLine("M3");
            M4();
            _tracer.StopTrace();
        }

        private void M4()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            Console.WriteLine("M4");
            _tracer.StopTrace();
        }
    }
}