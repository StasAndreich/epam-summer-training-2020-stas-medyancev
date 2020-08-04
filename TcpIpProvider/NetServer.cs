using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpIpProvider.ProviderEventArgs;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a simple TCP\IP server.
    /// </summary>
    public class NetServer //: IDisposable
    {
        /// <summary>
        /// Main server listener.
        /// </summary>
        private TcpListener tcpListener;
        public List<NetMessage> messages = new List<NetMessage>();

        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public NetServer(int port)
        {
            tcpListener = TcpListener.Create(port);
            this.MessageReceived += (sender, e) => AddMessage(e.message);
            tcpListener.Start(10);
        }

        /// <summary>
        /// Local server IP address.
        /// </summary>
        public IPAddress LocalAddress
        {
            get => ((IPEndPoint)tcpListener.LocalEndpoint).Address;
        }
        /// <summary>
        /// Server port.
        /// </summary>
        public int Port
        {
            get => ((IPEndPoint)tcpListener.LocalEndpoint).Port;
        }


        #region Server Events
        /// <summary>
        /// Triggers when some message received by a server.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        /// <summary>
        /// Method that invokes a MessageReceived event
        /// with MessageReceivedEventArgs.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            var handler = MessageReceived;
            handler?.Invoke(this, e);
        }
        #endregion


        #region Server Methods
        /// <summary>
        /// Starts listening for incoming
        /// connection requests.
        /// (Default backlog = 10).
        /// </summary>
        /// <param name="backLogSize"></param>
        public void StartServer(int backLogSize = 10)
        {
            
            
            while (true)
            {
                var newTcpClient = tcpListener.AcceptTcpClient();
                var netClient = new NetClient(newTcpClient);
                var process = Task.Run(() => ReceiveMessageAsync(netClient));
            }
        }

        /// <summary>
        /// Closes the server and
        /// disconnects all clients.
        /// </summary>
        public void Stop()
        {
            // Stop the server.
            tcpListener.Stop();
        }

        /// <summary>
        /// Reads a received message.
        /// </summary>
        /// <returns></returns>
        public void ReceiveMessageAsync(NetClient client)
        {
            var netStream = client.networkStream;
            var data = new byte[1024];
            var str = new StringBuilder();
            
            // Check if there is some data
            // is available.
            if (client.networkStream.DataAvailable) // while
            {
                try
                {
                    var bytesCount = netStream.Read(data, 0, 1024);
                    str.Append(Encoding.UTF8.GetString(data, 0, bytesCount));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            netStream.Flush();
            netStream.Close();

            // Create a new NetMessage and invoke the event.
            var message = new NetMessage(str.ToString());
            OnMessageReceived(new MessageReceivedEventArgs(client, message));
        }

        public void AddMessage(NetMessage message)
        {
            this.messages.Add(message);
        }

        /// <summary>
        /// Sends a string message
        /// to a TCP client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public void SendMessage(TcpClient client, string message)
        {
            var netStream = client?.GetStream();

            BinaryWriter writer = null;
            try
            {
                // Try to write data.
                using (writer = new BinaryWriter(netStream, Encoding.UTF8))
                {
                    writer.Write(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                writer?.Dispose();
            }
        }

        /// <summary>
        /// Subscribes a handler on when some
        /// message received by a server.
        /// </summary>
        /// <param name="handler"></param>
        public void SubscribeToReceivedMessages(EventHandler<MessageReceivedEventArgs> handler)
        {
            this.MessageReceived += handler;
        }
        #endregion
    }
}
