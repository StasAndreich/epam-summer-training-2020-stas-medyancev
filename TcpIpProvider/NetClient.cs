using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TcpIpProvider.ProviderEventArgs;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a TCP client.
    /// </summary>
    public class NetClient
    {
        /// <summary>
        /// Represents a TCP client functional.
        /// </summary>
        private TcpClient tcpClient;

        /// <summary>
        /// Creates a TCP client without connection.
        /// </summary>
        public NetClient()
        {
            tcpClient = new TcpClient();
        }

        /// <summary>
        /// Creates a NetClient from a TcpClient.
        /// </summary>
        /// <param name="client"></param>
        public NetClient(TcpClient client)
        {
            tcpClient = client;
        }

        /// <summary>
        /// Creates a TCP client using
        /// an IP address and a port to connect.
        /// This constructor will automatically 
        /// attempt a connection.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public NetClient(IPAddress address, int port)
        {
            tcpClient = new TcpClient(new IPEndPoint(address, port));
        }

        /// <summary>
        /// Local endpoint IP address.
        /// </summary>
        public IPAddress LocalAddress
        {
            get => IPAddress.Parse(
                ((IPEndPoint)tcpClient?.Client.LocalEndPoint)
                .Address.ToString());
        }
        /// <summary>
        /// Local endpoint port.
        /// </summary>
        public int LocalPort
        {
            get => ((IPEndPoint)tcpClient?.Client.LocalEndPoint)
                .Port;
        }
        /// <summary>
        /// Gets a buffer size of a client.
        /// </summary>
        public int ReceiveBufferSize { get => tcpClient.ReceiveBufferSize; }
        /// <summary>
        /// Gets a current client network stream.
        /// </summary>
        public NetworkStream NetStream
        {
            get => tcpClient.GetStream();
        }


        #region Client Events
        /// <summary>
        /// Triggers when some message comes from a server.
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


        #region Client Methods
        /// <summary>
        /// Sends a string message
        /// to a TCP server.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(message);
                NetStream.Write(data, 0, data.Length);
            }
            catch (Exception)
            {
                throw;
            }
            NetStream.Flush();
        }

        /// <summary>
        /// Reads a received message.
        /// </summary>
        /// <returns></returns>
        public void ReceiveMessage()
        {
            var data = new byte[ReceiveBufferSize];
            var message = new StringBuilder();

            try
            {
                var bytesCount = NetStream.Read(data, 0, ReceiveBufferSize);
                message.Append(Encoding.UTF8.GetString(data, 0, bytesCount));
            }
            catch (Exception)
            {
                throw;
            }
            NetStream.Flush();

            OnMessageReceived(new MessageReceivedEventArgs(this, message.ToString()));
        }

        /// <summary>
        /// Connects the client to the specified
        /// port on the specified host.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public void Connect(string hostname, int port)
        {
            tcpClient.Connect(hostname, port);
        }

        /// <summary>
        /// Connects the client to a remote TCP host
        /// using the specified IP address and port number.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void Connect(IPAddress address, int port)
        {
            tcpClient.Connect(address, port);
        }

        /// <summary>
        /// Requests that the underlying
        /// TCP connection be closed.
        /// </summary>
        public void Close()
        {
            tcpClient.Close();
        }
        #endregion


        /// <summary>
        /// Check the equality of this client
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var client = (NetClient)obj;

            return this.tcpClient.Equals(client.tcpClient);
        }

        /// <summary>
        /// Returns a hash-code for a NetClient object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return tcpClient.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// NetClient data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Client: {LocalAddress}:{LocalPort}";
        }
    }
}
