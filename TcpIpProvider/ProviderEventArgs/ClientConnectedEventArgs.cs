using System;

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
        public ClientConnectedEventArgs(NetClient newClient)
        {
            this.client = newClient;
        }

        /// <summary>
        /// Connected client.
        /// </summary>
        public readonly NetClient client;
    }
}
