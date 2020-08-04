using System;
using System.Net;
using System.Net.Sockets;
using TcpIpProvider.ProviderEventArgs;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a simple TCP\IP server.
    /// </summary>
    public class NetServer
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        /// <summary>
        /// Main server listener.
        /// </summary>
        private TcpListener tcpListener;

        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public NetServer(int port)
        {
            tcpListener = TcpListener.Create(port);
            this.ClientAccepted += (sender, e) =>ReceiveMessage(e.client);
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

        /// <summary>
        /// Triggers when a new client accepted to a server.
        /// </summary>
        public event EventHandler<ClientAcceptedEventArgs> ClientAccepted;
        /// <summary>
        /// Method that invokes a ClientConnected event
        /// with ClientConnectedEventArgs.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClientAccepted(ClientAcceptedEventArgs e)
        {
            var handler = ClientAccepted;
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
        public void Start(int backLogSize = 10)
        {
            tcpListener.Start(backLogSize);
            var token = tokenSource.Token;
            Task.Run(() 
                => WaitForNetClient(tokenSource.Token), token);
        }

        /// <summary>
        /// Operation of accepting a TCP NetClient.
        /// </summary>
        private void WaitForNetClient(CancellationToken token)
        { 
            while (!token.IsCancellationRequested)
            {
                var newTcpClient = tcpListener.AcceptTcpClient();
                var netClient = new NetClient(newTcpClient);
               OnClientAccepted(new ClientAcceptedEventArgs(netClient));
            }
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void Stop()
        {
            tokenSource.Cancel();
            // Stop the server.
            tcpListener.Stop();
        }

        /// <summary>
        /// Reads a received message.
        /// </summary>
        /// <returns></returns>
        public void ReceiveMessage(NetClient client)
        {
            var netStream = client.NetStream;
            var data = new byte[client.ReceiveBufferSize];
            var message = new StringBuilder();

            // Check if there is some data is available.
            if (netStream.DataAvailable)
            {
                try
                {
                    var bytesCount = netStream.Read(data, 0,
                        client.ReceiveBufferSize);
                    message.Append(Encoding.UTF8.GetString(data, 0, bytesCount));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            netStream.Flush();

            OnMessageReceived(new MessageReceivedEventArgs(client, message.ToString()));
        }

        /// <summary>
        /// Sends a string message
        /// to a TCP client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public void SendMessage(NetClient client, string message)
        {
            var netStream = client?.NetStream;

            try
            {
                var data = Encoding.UTF8.GetBytes(message);
                netStream.Write(data, 0, data.Length);
            }
            catch (Exception)
            {
                throw;
            }
            netStream.Flush();
        }
        #endregion


        /// <summary>
        /// Check the equality of this server
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var server = (NetServer)obj;

            return this.tcpListener.Equals(server.tcpListener);
        }

        /// <summary>
        /// Returns a hash-code for a server obj.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return tcpListener.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// server data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Server: {LocalAddress}:{Port}";
        }
    }
}
