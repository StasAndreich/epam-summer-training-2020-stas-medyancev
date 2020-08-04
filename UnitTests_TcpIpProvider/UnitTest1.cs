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

            var cTask = Task.Run(() =>
            {
                server.StartServer();
            });

            var client = new NetClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 5555);
            client.SendMessage("Message");
            client.Close();

            var message = new NetMessage("Message");
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
