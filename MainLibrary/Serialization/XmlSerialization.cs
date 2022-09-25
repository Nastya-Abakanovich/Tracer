using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MainLibrary.Result;

namespace MainLibrary.Serialization
{
    public class XmlSerialization: ISerialization
    {
        public string Serialize(TraceResult result)
        {
            string serializeResult;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(writer, result);
                }
                return textWriter.ToString();
            }
        }
    }
}
