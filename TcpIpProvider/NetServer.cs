using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpIpProvider.ProviderEventArgs;
using System.Text;

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
        public string mes;

        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public NetServer(int port)
        {
            tcpListener = TcpListener.Create(port);
            this.ClientConnected += (sender, e) => ReceiveMessage(e.client);
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
        /// Triggers when a new client connects to a server.
        /// </summary>
        public event EventHandler<ClientConnectedEventArgs> ClientConnected;
        /// <summary>
        /// Method that invokes a ClientConnected event
        /// with ClientConnectedEventArgs.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClientConnected(ClientConnectedEventArgs e)
        {
            var handler = ClientConnected;
            handler?.Invoke(this, e);
        }

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
        public async void StartServer(int backLogSize = 10)
        {
            tcpListener.Start(backLogSize);
            
            while (true)
            {
                var newClient = await tcpListener.AcceptTcpClientAsync();
                OnClientConnected(new ClientConnectedEventArgs(newClient));
            }
        }
        
        //public async void Listen()
        //{
        //    while (true)
        //    {
        //        var newClient = await tcpListener.AcceptTcpClientAsync();
        //        OnClientConnected(new ClientConnectedEventArgs(newClient)); 
        //    }
        //}

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
        public async void ReceiveMessageAsync(TcpClient client)
        {
            // Get a client's NetworkStream.
            var netStream = client?.GetStream();
            var data = new byte[client.ReceiveBufferSize];
            
            // Check if there is some data
            // is available.
            if (netStream.DataAvailable)
            {
                try
                {
                    var bytesCount = netStream.Read(data, 0, (int)client.ReceiveBufferSize);
                    mes = Encoding.UTF8.GetString(data, 0, bytesCount);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            netStream.Flush();
            netStream.Close();
            // Create a new NetMessage
            // and invoke the event.
            var message = new NetMessage(mes,
                                         timeStamp: DateTime.Now);
            OnMessageReceived(new MessageReceivedEventArgs(client, message));
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
