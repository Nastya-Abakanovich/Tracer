using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Writer
{
    public class FileWriter: IWriter
    {
        private string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string value)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                writer.WriteLineAsync(value);
            }
        }
    }
}
