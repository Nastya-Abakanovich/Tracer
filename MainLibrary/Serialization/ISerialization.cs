using MainLibrary.Result;

namespace MainLibrary.Serialization
{
    public interface ISerialization
    {
        string Serialize(TraceResult result);
    }
}
