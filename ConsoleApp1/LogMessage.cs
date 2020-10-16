using System;

namespace ConsoleApp1
{
    public class LogMessage : ILogMessage
    {
        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void DisplayInlineMessage(string msg)
        {
            Console.Write(msg);
        }
    }
}
