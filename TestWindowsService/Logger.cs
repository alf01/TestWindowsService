using System.Configuration;
using System.IO;

namespace TestWindowsService
{
    public static class Logger
    {
        private static readonly string FilePath = ConfigurationManager.AppSettings["LogFilePath"];

        public static void Append(ResultMessage message)
        {
            using (var streamWriter = new StreamWriter(FilePath, true))
            {
                streamWriter.WriteLine(message.ToString());
            }
        }
    }
}