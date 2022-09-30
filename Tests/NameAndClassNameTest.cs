using MainLibrary;
using MainLibrary.Result;
namespace Tests
{
    [TestFixture]
    public class NameAndClassNameTest
    {
        private TraceResult _traceResult;

        [OneTimeSetUp]
        public void SetUp()
        {
            ITracer tracer = new Tracer();
            ClassA A = new ClassA(tracer);
            ClassB B = new ClassB(tracer);

            A.M0();
            B.M1();

            _traceResult = tracer.GetTraceResult();
        }        

        [Test]
        public void GetTraceResult_FirstNestingLevel_ReturnsSameName()
        {
            string className1 = _traceResult.Threads[0].Methods[0].ClassName;
            string name1 = _traceResult.Threads[0].Methods[0].Name;
            string className2 = _traceResult.Threads[0].Methods[1].ClassName;
            string name2 = _traceResult.Threads[0].Methods[1].Name;

            Assert.AreEqual("ClassA", className1, "Invalid class name for class ClassA");
            Assert.AreEqual("M0", name1, "Invalid method name for method ClassA.M0");
            Assert.AreEqual("ClassB", className2, "Invalid class name for class ClassB");
            Assert.AreEqual("M1", name2, "Invalid method name for method ClassB.M1");
        }

        [Test]
        public void GetTraceResult_SecondNestingLevel_ReturnsSameName()
        {
            string className1 = _traceResult.Threads[0].Methods[0].Methods[0].ClassName;
            string name1 = _traceResult.Threads[0].Methods[0].Methods[0].Name;
            string className2 = _traceResult.Threads[0].Methods[0].Methods[1].ClassName;
            string name2 = _traceResult.Threads[0].Methods[0].Methods[1].Name;

            Assert.AreEqual("ClassA", className1, "Invalid class name for class ClassA");
            Assert.AreEqual("M1", name1, "Invalid method name for method ClassA.M1");
            Assert.AreEqual("ClassB", className2, "Invalid class name for class ClassB");
            Assert.AreEqual("M1", name2, "Invalid method name for method ClassB.M1");
        }

        [Test]
        public void GetTraceResult_ThirdNestingLevel_ReturnsSameName()
        {
            string className = _traceResult.Threads[0].Methods[0].Methods[0].Methods[0].ClassName;
            string name = _traceResult.Threads[0].Methods[0].Methods[0].Methods[0].Name;

            Assert.AreEqual("ClassA", className, "Invalid class name for class ClassA");
            Assert.AreEqual("M2", name, "Invalid method name for method ClassA.M2");
        }
    }

}