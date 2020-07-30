using System;
using System.Net;
using System.Net.Sockets;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a simple TCP\IP server.
    /// </summary>
    public class TcpServer
    {
        /// <summary>
        /// Inits a TCP server listening to any
        /// client activity on a defined port.
        /// </summary>
        /// <param name="port"></param>
        public TcpServer(int port)
        {
            this.Port = port;
            listener = new TcpListener(IPAddress.Any, port);
        }

        /// <summary>
        /// Inits a TCP server listening to 
        /// defined address and port.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public TcpServer(IPAddress address, int port)
            : this(port)
        {
            this.LocalAddress = address;
            listener = new TcpListener(address, port);
        }
        
        private TcpListener listener;

        /// <summary>
        /// Local server IP address.
        /// </summary>
        public IPAddress LocalAddress { get; set; }

        /// <summary>
        /// Server port.
        /// </summary>
        public int Port { get; set; }
    }
}
