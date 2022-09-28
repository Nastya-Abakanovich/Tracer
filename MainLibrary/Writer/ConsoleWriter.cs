namespace MainLibrary.Writer
{
    public class ConsoleWriter: IWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value);   
        }
    }
}
