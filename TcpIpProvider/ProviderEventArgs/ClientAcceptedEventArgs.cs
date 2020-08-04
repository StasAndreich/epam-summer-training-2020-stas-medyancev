using System;

namespace TcpIpProvider.ProviderEventArgs
{
    /// <summary>
    /// Represents args for ClientAccepted event.
    /// </summary>
    public class ClientAcceptedEventArgs : EventArgs
    {
        /// <summary>
        /// Inits event args with a NetClient.
        /// </summary>
        /// <param name="newClient"></param>
        public ClientAcceptedEventArgs(NetClient newClient)
        {
            this.client = newClient;
        }

        /// <summary>
        /// Accepted client.
        /// </summary>
        public readonly NetClient client;
    }
}
