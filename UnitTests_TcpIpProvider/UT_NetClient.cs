using TcpIpProvider;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading;

namespace UnitTests_TcpIpProvider
{
    [TestClass]
    public class UT_NetClient
    {
        [TestMethod]
        public void Case_SendFromClientToServer_Success()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var messageForSending = "Message";
            var receivedMessage = "";

            // Create a server.
            var server = new NetServer(5555);
            server.MessageReceived += (sender, e) =>
            {
                receivedMessage = e.message;
            };

            // Create client.
            var clientTask = Task.Run(() =>
            {
                var client = new NetClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 5555);
                client.SendMessage(messageForSending);
                client.Close();
            });

            // Start the server.
            //var serverTask = Task.Run(() => server.Start(), token);
            server.Start();

            clientTask.Wait();
            //tokenSource.Cancel();
            server.Stop();

            if (receivedMessage.Equals(messageForSending))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void Case_SendFromServerToClient_Success()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var messageForSending = "Message";
            var receivedMessage = "";

            // Create a server.
            var server = new NetServer(5555);
            server.Start();
            server.ClientAccepted += (sender, e) =>
            {
                server.SendMessage(e.client, messageForSending);
                tokenSource.Cancel();
                server.Stop();
            };

            // Create client.
            var clientTask = Task.Run(() =>
            {
                var client = new NetClient();
                client.MessageReceived += (sender, e) =>
                    receivedMessage = e.message;
                client.Connect(IPAddress.Parse("127.0.0.1"), 5555);
                client.ReceiveMessage();
                client.Close();
            });

            clientTask.Wait();
            server.Stop();

            if (receivedMessage.Equals(messageForSending))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
