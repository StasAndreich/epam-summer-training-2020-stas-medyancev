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
    public class NetServer
    {
        /// <summary>
        /// Main server listener.
        /// </summary>
        private TcpListener listener;
        /// <summary>
        /// Connected clients list.
        /// </summary>
        private List<TcpClient> serverClients = new List<TcpClient>();


        // Move to another class.
        //private IDictionary<NetClient, List<NetMessage>> messageHistory;

        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public NetServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            this.ClientConnected += (sender, e) => ReadMessage(e.client);
        }

        /// <summary>
        /// Inits a TCP server listening to 
        /// defined address and port.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public NetServer(string address, int port)
            : this(port)
        {
            listener = new TcpListener(IPAddress.Parse(address), port);
        }

        /// <summary>
        /// Local server IP address.
        /// </summary>
        public IPAddress LocalAddress
        {
            get => ((IPEndPoint)listener.LocalEndpoint).Address;
        }
        /// <summary>
        /// Server port.
        /// </summary>
        public int Port
        {
            get => ((IPEndPoint)listener.LocalEndpoint).Port;
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
        public void Start(int backLogSize = 10)
        {
            listener.Start(backLogSize);

            while (true)
            {
                // Accept a client if there is one.
                var newClient = listener.AcceptTcpClient();
                OnClientConnected(new ClientConnectedEventArgs(newClient));
            }
        }

        /// <summary>
        /// Closes the server and
        /// disconnects all clients.
        /// </summary>
        public void Stop()
        {
            // Stop the server.
            listener.Stop();

            // Close all the clients.
            foreach (var client in serverClients)
                client?.Close();
        }

        /// <summary>
        /// Reads a received message.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public NetMessage ReadMessage(TcpClient client)
        {
            // Get a client's NetworkStream.
            var netStream = client.GetStream();
            var mes = "";

            // Read message data.
            //if (netStream.DataAvailable)
            //{
            //    //using (var reader = new BinaryReader(netStream))
            //    //{
            //    //    data = reader.ReadString();
            //    //}

            //}
            byte[] data = new byte[256];
            var tmp = new StringBuilder();
            while (netStream.DataAvailable)
            {
                int bytes = netStream.Read(data, 0, data.Length);
                tmp.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            netStream.Close();
            // Create a NetMessage.
            return new NetMessage(mes, timeStamp: DateTime.Now);
        }

        /// <summary>
        /// Sends a string message via 
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            var netStream = currentClient.GetStream();

            byte[] bytes = Encoding.UTF8.GetBytes(message);
            //using (var writer = new BinaryWriter(netStream))
            //{
            //    writer.Write(message);
            //}
            netStream.Write(bytes, 0, bytes.Length);

            netStream.Close();
        }

        //public void SendMessageTo(string message, IPAddress address)
        //{

        //}

        public void SubscribeToReceivedMessages(EventHandler<MessageReceivedEventArgs> handler)
        {
            this.MessageReceived += (sender, e) => handler(e.);
        }
        #endregion
    }
}
