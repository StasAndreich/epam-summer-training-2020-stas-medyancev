using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpIpProvider;
using System.Threading.Tasks;

namespace UnitTests_TcpIpProvider
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var server = new NetServer("127.0.0.1", 8888);
            var task = Task.Run(() => server.Start());

            var client = new NetClient("127.0.0.1", 8888);
            // connect.
            // client in task.
            client.Send("Start");
            //client.Connect(IPAddress.Parse("127.0.0.1"), 8888);
        }
    }
}
