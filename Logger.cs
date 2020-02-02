using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Logger : ILogger
    {
        public Logger()
        {
            Console.WriteLine("Console Logger initiated");
        }

        public void Log(string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg)) {
                Console.WriteLine(msg);
            }
        }

        public void Log(Exception ex)
        {
            if (ex != null) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
