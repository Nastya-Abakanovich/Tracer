using MainLibrary;
using MainLibrary.Result;

namespace Tests
{
    [TestFixture]
    public class MultithreadingTest
    {
        private TraceResult _traceResult;

        [OneTimeSetUp]
        public void SetUp()
        {
            object Locker = new();
            ITracer tracer = new Tracer();
            ClassA A = new ClassA(tracer);
            ClassB B = new ClassB(tracer);

            Thread thread1 = new Thread(() => {
                lock (Locker)
                {
                    A.M1();
                    A.M2();
                }
            });
            Thread thread2 = new Thread(() => {
                lock (Locker)
                {
                    B.M1();
                }
            });

            thread1.Start();
            thread2.Start();

            lock (Locker)
            {
                A.M0();
                B.M1();
            }

            thread1.Join();
            thread2.Join();
            _traceResult = tracer.GetTraceResult();
        }

        [Test]
        public void GetTraceResult_ThreadsNumber_ReturnsSameNumber()
        {
            const int requiredThreadsNumber = 3;
            int threadsNumber = _traceResult.Threads.Count;

            Assert.AreEqual(requiredThreadsNumber, threadsNumber, "Invalid number of threads");
        }

        [Test]
        public void GetTraceResult_FirstThreadMethodsNumber_ReturnsSameNumber()
        {
            int methodsNumber1 = _traceResult.Threads[0].Methods.Count;
            int methodsNumber2 = _traceResult.Threads[1].Methods.Count;
            int methodsNumber3 = _traceResult.Threads[2].Methods.Count;

            bool result = (methodsNumber1 == 1 && methodsNumber2 == 2 && methodsNumber3 == 2) ||
                          (methodsNumber1 == 2 && methodsNumber2 == 1 && methodsNumber3 == 2) ||
                          (methodsNumber1 == 2 && methodsNumber2 == 2 && methodsNumber3 == 1);

            Assert.IsTrue(result, $"Number of methods equals {methodsNumber1}, {methodsNumber2}, {methodsNumber3} instead of 2, 2, 1.");
        }
    }
}
