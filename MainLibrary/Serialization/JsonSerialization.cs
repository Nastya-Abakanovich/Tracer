using System.Text.Json;

namespace MainLibrary.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public string Serialize(Result.TraceResult result)
        {
            var changeableResult = new ChangeableResult.ChangeableTraceResult(result);
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(changeableResult, options);
        }
    }
}
