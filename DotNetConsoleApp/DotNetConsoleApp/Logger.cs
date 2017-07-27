using System;

namespace DotNetConsoleApp
{
    public class Logger : ILogger
    {
        public bool isAdmin { get; set; }
        public string file { get; set; }

        Logger(bool isAdmin, string file)
        {
            this.isAdmin = isAdmin;
            this.file = file;
        }

        public void log(string message)
        {
            if (isAdmin)
                Console.WriteLine("Sending SMS Message: {0}", message);
            else
                Console.WriteLine("Logging {0} to {1}.", message, file);
        }
    }
}