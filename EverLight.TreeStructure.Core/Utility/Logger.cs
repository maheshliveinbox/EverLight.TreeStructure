using System;

namespace EverLight.TreeStructure.Core.Utility
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
