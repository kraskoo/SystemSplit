namespace SystemSplit.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string format, params object[] arguments)
        {
            Console.WriteLine(format, arguments);
        }
    }
}