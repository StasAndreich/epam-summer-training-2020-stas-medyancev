using System;
using System.Net.Sockets;

namespace TcpIpProvider.ProviderEventArgs
{
    /// <summary>
    /// Represents args for ClientConnected event.
    /// </summary>
    public class ClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// Inits event args with a TcpClient.
        /// </summary>
        /// <param name="newClient"></param>
        public ClientConnectedEventArgs(TcpClient newClient)
        {
            this.client = newClient;
        }

        /// <summary>
        /// Connected client.
        /// </summary>
        public readonly TcpClient client;
    }
}
