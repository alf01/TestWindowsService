using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using TestWindowsService;
using System.Threading;


namespace TestWindowsSercive.UnitTests
{
    [TestClass]
    public class ApiRequestTest
    {
        [TestMethod]
        public void IntegratedTestApi()
        {
            string baseAddress = "http://localhost:9000/";
            WebRequest request = WebRequest.Create(baseAddress + "api/status");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            Assert.IsTrue(responseFromServer == "true");

        }
    }
}
