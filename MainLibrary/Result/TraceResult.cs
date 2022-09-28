using System.Xml.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInfo> Threads { get; }

        internal TraceResult(ChangeableTraceResult result)
        {
            List<ThreadInfo>  threads = new List<ThreadInfo>();

            foreach(ChangeableThreadInfo thread in result.Threads)
            {
                threads.Add(new ThreadInfo(thread));
            }
            Threads = threads;
        }
    }
}
