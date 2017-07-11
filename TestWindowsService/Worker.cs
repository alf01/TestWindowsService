using System;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;

namespace TestWindowsService
{
    public class Worker : IDisposable
    {
        private const string BaseAddress = "http://localhost:9000/";
        private readonly IDisposable server;

        private readonly List<StatusRequest> requests = new List<StatusRequest>();

        public Worker()
        {
            server = WebApp.Start<Startup>(BaseAddress);
        }

        public void Start()
        {
            requests.Add(new StatusRequest("http://www.google.com", 120000));
            requests.Add(new StatusRequest("http://www.apple.com", 300000));
            requests.Add(new StatusRequest("http://www.microsoft.com", 22, 15, 2, DateTime.Now));
        }

        public void Dispose()
        {
            requests.ForEach(x => x.Dispose());

            server?.Dispose();
        }
    }
}