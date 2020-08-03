using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using TcpIpProvider.ProviderEventArgs;

namespace TcpIpProvider
{
    /// <summary>
    /// Represents a delegate that refers to a method
    /// that encodes an input string.
    /// </summary>
    /// <param name="inputStr"></param>
    /// <returns></returns>
    public delegate string EncodeString(string inputStr);// ???

    /// <summary>
    /// Defines a TCP client.
    /// </summary>
    public class NetClient
    {
        /// <summary>
        /// Represents a TCP client
        /// functional.
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Creates a TCP client without connection.
        /// </summary>
        public NetClient()
        {
            client = new TcpClient();
        }

        /// <summary>
        /// Creates a TCP client using
        /// a host name and a port to connect.
        /// This constructor will automatically 
        /// attempt a connection.
        /// </summary>
        /// <param name="hostname">
        /// The DNS name of the remote 
        /// host to which you intend 
        /// to connect.</param>
        /// <param name="port"></param>
        public NetClient(string hostname, int port)
        {
            client = new TcpClient(hostname, port);
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
            client = new TcpClient(new IPEndPoint(address, port));
        }

        /// <summary>
        /// Local endpoint IP address.
        /// </summary>
        public IPAddress LocalEndPointAddress
        {
            get => IPAddress.Parse(
                ((IPEndPoint)client?.Client.LocalEndPoint)
                .Address.ToString());
        }
        /// <summary>
        /// Local endpoint port.
        /// </summary>
        public int LocalEndPointPort
        {
            get => ((IPEndPoint)client?.Client.LocalEndPoint)
                .Port;
        }


        #region Client Events
        /// <summary>
        /// Triggers when some message comes to a client.
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
            var netStream = client.GetStream();

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
            netStream.Close();
        }

        /// <summary>
        /// Reads a received message.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public void ReadMessage(TcpClient client)
        {
            // Get a server's NetworkStream.
            var netStream = client.GetStream();
            var data = new StringBuilder();

            // Check if there is some data
            // available.
            if (netStream.DataAvailable)
            {
                BinaryReader reader = null;
                try
                {
                    // Try to read data.
                    using (reader = new BinaryReader(netStream, Encoding.UTF8))
                    {
                        data.Append(reader.ReadString());
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    reader?.Dispose();
                }
            }

            // Create a new NetMessage
            // and invoke the event.
            var message = new NetMessage(data.ToString(),
                                         timeStamp: DateTime.Now);
            OnMessageReceived(new MessageReceivedEventArgs(client, message));
        }

        /// <summary>
        /// Connects the client to the specified
        /// port on the specified host.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public void Connect(string hostname, int port)
        {
            client.Connect(hostname, port);
        }

        /// <summary>
        /// Connects the client to a remote TCP host
        /// using the specified IP address and port number.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void Connect(IPAddress address, int port)
        {
            client.Connect(address, port);
        }

        /// <summary>
        /// Requests that the underlying
        /// TCP connection be closed.
        /// </summary>
        public void Close()
        {
            client.Close();
        }
        #endregion


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
