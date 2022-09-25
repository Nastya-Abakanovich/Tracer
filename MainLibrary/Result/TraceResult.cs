namespace MainLibrary.Result
{
    public class TraceResult
    {
        public List<ThreadInfo> Threads;

        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }
    }
}
