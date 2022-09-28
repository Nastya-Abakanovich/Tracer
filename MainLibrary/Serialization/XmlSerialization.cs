using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MainLibrary.ChangeableResult;

namespace MainLibrary.Serialization
{
    public class XmlSerialization: ISerialization
    {
        public string Serialize(Result.TraceResult result)
        {
            ChangeableTraceResult changeableResult = new ChangeableTraceResult(result);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ChangeableTraceResult));

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(writer, changeableResult);
                }
                return textWriter.ToString();
            }
        }
    }
}
