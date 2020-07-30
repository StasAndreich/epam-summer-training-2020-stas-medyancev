using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a simple TCP\IP server.
    /// </summary>
    public class NetServer
    {
        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public NetServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);

            this.MessageReceived += (sender, e) =>
            {

            };
        }

        /// <summary>
        /// Inits a TCP server listening to 
        /// defined address and port.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public NetServer(IPAddress address, int port)
            : this(port)
        {
            listener = new TcpListener(address, port);
        }
        
        private TcpListener listener;

        ///// <summary>
        ///// Indicates whether a server is
        ///// listening to incoming clients.
        ///// </summary>
        //public bool IsListening;

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

        /// <summary>
        /// Triggers when some message comes to a server.
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


        #region Server Methods
        /// <summary>
        /// Starts listening for incoming
        /// connection requests.
        /// </summary>
        public void Start()
        {
            listener.Start();
        }

        /// <summary>
        /// Closes the server.
        /// </summary>
        public void Stop()
        {
            listener.Stop();
        }

        /// <summary>
        /// Waits for a client connection and
        /// reads an income data.
        /// </summary>
        public void Accept()
        {
            // Accept a client if there is one.
            var client = listener.AcceptTcpClient();
            // Get a client NetworkStream.
            var netStream = client.GetStream();

            var message = "";

            if (netStream.DataAvailable)
            {
                var reader = new StreamReader(netStream);
                message = reader.ReadToEnd();
            }

            // Invoke an event.
            OnMessageReceived(new MessageReceivedEventArgs(client,
                                                           timeStamp: DateTime.Now,
                                                           message));
        }

        /// <summary>
        /// Sends a string message via 
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {

        }

        public void SendTo(string message, IPAddress address)
        {

        } 
        #endregion
    }

    /// <summary>
    /// Defines a MessageReceived event args.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Inits MessageReceivedEventArgs with
        /// a client and a message.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="timeStamp"></param>
        /// <param name="message"></param>
        public MessageReceivedEventArgs(NetClient client,
                                        DateTime timeStamp,
                                        string message)
        {
            this.client = client;
            this.timeStamp = timeStamp;
            this.message = message;
        }

        
        /// <summary>
        /// A time stamp of a received message.
        /// </summary>
        public readonly DateTime timeStamp;
        /// <summary>
        /// Keeps a message pushed on a server.
        /// </summary>
        public readonly string message;
    }
}
