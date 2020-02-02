using System;

namespace ConsoleApp1
{
    class FileLogger : ILogger
    {
        private static FileLogger loggerInstance_;

        public string Filename { get; private set; }

        private FileLogger(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) {
                throw new ArgumentNullException(nameof(filename));
            }

            Filename = filename;
        }

        public void Log(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) {
                return;
            }

            Write(msg);
        }

        public void Log(Exception ex)
        {
            if (ex == null) {
                return;
            }

            Write(ex.Message);
        }

        private void Write(string msg)
        {
            System.IO.File.AppendAllText(Filename,
                $"{DateTime.UtcNow}: {msg}\n");
        }

        public static ILogger GetInstance()
        {
            if (loggerInstance_ == null) {
                loggerInstance_ = new FileLogger(
                    "log.txt");
            }

            return loggerInstance_;
        }
    }
}
