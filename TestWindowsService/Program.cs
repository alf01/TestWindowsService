using System;
using System.ServiceProcess;

namespace TestWindowsService
{
    public static class Program
    {
        public static void Main()
        {
            if (Environment.UserInteractive)
            {
                using (var worker = new Worker())
                {
                    Console.WriteLine("Starting service...");
                    worker.Start();

                    Console.WriteLine("Service is running.");
                    Console.WriteLine("Press any key to stop...");
                    Console.ReadKey();

                    return;
                }
            }

            ServiceBase.Run(new ServiceBase[] { new TestWindowsService() });
        }
    }
}