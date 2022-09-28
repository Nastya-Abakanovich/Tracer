using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using MainLibrary.Result;

namespace MainLibrary.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public string Serialize(TraceResult result)
        {
            var traceResult = new TraceResult();
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(traceResult, options);
        }
    }
}
