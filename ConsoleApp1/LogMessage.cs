using System;

namespace ConsoleApp1
{
    public class LogMessage : ILogMessage
    {
        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
