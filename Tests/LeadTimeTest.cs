using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLibrary;
using MainLibrary.Result;

namespace Tests
{
    [TestFixture]
    public class LeadTimeTest
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
        public void GetTraceResult_ThirdNestingLevel_ReturnsSimilarLeadTime()
        {
            const double epsilon = 15;
            const double requiredLeadTime = 200;
            double leadTime = _traceResult.Threads[0].Methods[0].Methods[0].Methods[0].LeadTime;

            Assert.IsTrue(Math.Abs(leadTime - requiredLeadTime) <= epsilon, 
                          $"Lead time for method ClassA.M2 equals {leadTime} instead of {requiredLeadTime}");
        }

        [Test]
        public void GetTraceResult_SecondNestingLevel_ReturnsSimilarLeadTime()
        {
            const double epsilon = 15;
            const double requiredLeadTime1 = 300;
            const double requiredLeadTime2 = 150;
            double leadTime1 = _traceResult.Threads[0].Methods[0].Methods[0].LeadTime;
            double leadTime2 = _traceResult.Threads[0].Methods[0].Methods[1].LeadTime;

            Assert.IsTrue(Math.Abs(leadTime1 - requiredLeadTime1) <= 2 * epsilon, 
                          $"Lead time for method ClassA.M1 equals {leadTime1} instead of {requiredLeadTime1}");
            Assert.IsTrue(Math.Abs(leadTime2 - requiredLeadTime2) <= epsilon, 
                          $"Lead time for method ClassB.M1 equals {leadTime2} instead of {requiredLeadTime2}");
        }

        [Test]
        public void GetTraceResult_FirstNestingLevel_ReturnsSimilarLeadTime()
        {
            const double epsilon = 15;
            const double requiredLeadTime1 = 500;
            const double requiredLeadTime2 = 150;
            double leadTime1 = _traceResult.Threads[0].Methods[0].LeadTime;
            double leadTime2 = _traceResult.Threads[0].Methods[1].LeadTime;

            Assert.IsTrue(Math.Abs(leadTime1 - requiredLeadTime1) <= 3 * epsilon, 
                          $"Lead time for method ClassA.M0 equals {leadTime1} instead of {requiredLeadTime1}");
            Assert.IsTrue(Math.Abs(leadTime2 - requiredLeadTime2) <= epsilon, 
                          $"Lead time for method ClassB.M1 equals {leadTime2} instead of {requiredLeadTime2}");
        }
    }
}
