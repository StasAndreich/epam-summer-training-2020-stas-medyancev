using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpIpProvider;
using System.Threading.Tasks;
using System.Threading;

namespace UnitTests_TcpIpProvider
{
    [TestClass]
    public class UT_NetServer
    {
        [TestMethod]
        public void TestMethod1()
        {
            var server = new NetServer(5555);

            var clientTask = Task.Run(() =>
            {
                var client = new NetClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 5555);
                client.SendMessage("Message");
                client.SendMessage("Message1");
            });

            server.Start();
            

            Thread.Sleep(100);
            server.Stop();

            var message = new NetMessage("MessageMessage1");
            if (server.messages[0].Data.Equals(message.Data))
            {
                Assert.IsTrue(true);
                server.Stop();
            }
            else
            {
                Assert.IsTrue(false);
                server.Stop();
            }
            
        }
    }
}
