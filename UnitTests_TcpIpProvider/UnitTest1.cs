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
            var server = new NetServer(5555);
            server.Start();
            var task = Task.Run(() => server.Listen());

            var client = new NetClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 5555);
            client.SendMessage("Message");
            client.SendMessage("Message1");
            client.Close();
            //task.Wait();
            if (server.mes == "Message1")
            {
                Assert.IsTrue(true);
                server.Stop();
                return;
            }

            //server.


            server.Stop();
            Assert.IsTrue(false);
        }
    }
}
