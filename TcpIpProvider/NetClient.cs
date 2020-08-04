using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
        /// Represents a TCP client functional.
        /// </summary>
        private TcpClient tcpClient;
        /// <summary>
        /// Keeps current client network stream.
        /// </summary>
        public NetworkStream networkStream;

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
            networkStream = tcpClient.GetStream();
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
            var netStream = tcpClient.GetStream();

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
            var message = new NetMessage(data.ToString());
            OnMessageReceived(new MessageReceivedEventArgs(new NetClient(client), message));
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
            networkStream = tcpClient.GetStream();
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
