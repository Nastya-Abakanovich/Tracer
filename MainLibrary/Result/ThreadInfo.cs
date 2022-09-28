using MainLibrary.ChangeableResult;

namespace MainLibrary.Result
{
    public class ThreadInfo
    {
        public int Id { get;}
        public double LeadTime { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        internal ThreadInfo(ChangeableThreadInfo thread)
        {
            Id = thread.Id;
            LeadTime = thread.LeadTime;

            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (ChangeableMethodInfo method in thread.Methods)
            {
                methods.Add(new MethodInfo(method));
            }
            Methods = methods;
        }

    }
}
