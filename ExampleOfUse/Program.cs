using MainLibrary;
using MainLibrary.Result;
using MainLibrary.Serialization;
using MainLibrary.Writer;

namespace ExampleOfUse
{
    internal class Program
    {
        static private Tracer _tracer;

        static void Main()
        {
            _tracer = new Tracer();

            Thread thread1 = new Thread(Thread1);
            Thread thread2 = new Thread(Thread2);                       
          
            thread1.Start();
            thread2.Start();

            Foo foo = new Foo(_tracer);
            foo.MyMethod();                          

            thread1.Join();
            thread2.Join();
            TraceResult traceResult = _tracer.GetTraceResult();

            ISerialization ser = new JsonSerialization();
            string strJson = ser.Serialize(traceResult);

            ISerialization serx = new XmlSerialization();
            string strXml = serx.Serialize(traceResult);
            
            IWriter ConsoleWriter = new ConsoleWriter();
            ConsoleWriter.Write(strJson);
            ConsoleWriter.Write(strXml);

            IWriter FileWriterJson = new FileWriter("1.json");
            FileWriterJson.Write(strJson);

            IWriter FileWriterXml = new FileWriter("1.xml");
            FileWriterXml.Write(strXml);
        }

        static public void Thread1()
        {
            Foo foo = new Foo(_tracer);
            
            foo.MyMethod();
            foo.MySecondMethod();            
        }
        static public void Thread2()
        {
            Foo foo = new Foo(_tracer);
            Bar bar = new Bar(_tracer);
     
            foo.MyMethod();
            bar.InnerMethod();       
        }
    }
}