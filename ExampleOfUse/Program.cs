using MainLibrary;
using MainLibrary.Result;
using MainLibrary.Serialization;
using MainLibrary.Writer;

namespace ExampleOfUse
{
    internal class Program
    {
        static private Tracer _tracer;
        static object Locker = new();

        static void Main()
        {
            _tracer = new Tracer();

            Thread thread1 = new Thread(Thread1);
            Thread thread2 = new Thread(Thread2);

            Foo foo = new Foo(_tracer);
            
          
            thread1.Start();  // запускаем поток myThread1
            thread2.Start();

            lock (Locker) 
            {
                foo.MyMethod();
            }                

            thread1.Join();
            thread2.Join();
            TraceResult trRes = _tracer.GetTraceResult();

            ISerialization ser = new JsonSerialization();
            string strjson = ser.Serialize(trRes);

            ISerialization serx = new XmlSerialization();
            string strxml = serx.Serialize(trRes);

            IWriter cWriter = new ConsoleWriter();
            cWriter.Write(strjson);
            cWriter.Write(strxml);

           //  IWriter fWriter = new FileWriter("1.xml");
           //  fWriter.Write(str);


        }

        static public void Thread1()
        {
            Foo foo = new Foo(_tracer);
            
            lock (Locker)
            {
                foo.MyMethod();
                foo.MyMethod();
            }
            
        }
        static public void Thread2()
        {
            Foo foo = new Foo(_tracer);
            Bar bar = new Bar(_tracer);
            lock (Locker)
            {
                foo.MyMethod();
                bar.InnerMethod();
            }

        }
    }

}