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
        private TcpClient client;

        /// <summary>
        /// Creates a TCP client with
        /// IP address and port.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public NetClient(string address, int port)
        {
            client = new TcpClient(address, port);
        }

        public string LocalName;

        public int Id;

        ///// <summary>
        ///// Local server IP address.
        ///// </summary>
        //public IPAddress LocalAddress
        //{
        //    get => ((IPEndPoint)client.).Address;
        //}
        ///// <summary>
        ///// Server port.
        ///// </summary>
        //public int Port
        //{
        //    get => ((IPEndPoint)client.LocalEndpoint).Port;
        //}

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

        public void Connect(IPAddress address, int port)
        {
            client.Connect(address, port);
        }

        public void Disconnect()
        {

        }

        public void Close()
        {
            client.Close();
        }

        public void Send(string message) // choose server
        {
            var netStream = client.GetStream();

            //// Send message.
            //using (var writer = new StreamWriter(netStream))
            //{
            //    writer.Write(message);
            //}

            byte[] bytes = Encoding.UTF8.GetBytes(message);
            netStream.Write(bytes, 0, bytes.Length);


            netStream.Close();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
