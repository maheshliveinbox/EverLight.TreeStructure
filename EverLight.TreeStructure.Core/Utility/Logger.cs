using System;

namespace EverLight.TreeStructure.Core.Utility
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void StartApplication()
        {
            Console.WriteLine("Start application !");
        }

        public void EndApplication()
        {
            Console.WriteLine("Press any key to continue....");
            Console.ReadLine();
        }
    }
}
