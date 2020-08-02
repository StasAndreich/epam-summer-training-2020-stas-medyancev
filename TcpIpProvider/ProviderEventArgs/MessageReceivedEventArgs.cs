using System;
using System.Net.Sockets;

namespace TcpIpProvider.ProviderEventArgs
{
    /// <summary>
    /// Defines a MessageReceived event args.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Default ctor that inits args
        /// with a TcpClient.
        /// </summary>
        /// <param name="client"></param>
        public MessageReceivedEventArgs(TcpClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Stores a TcpClient that sent
        /// received message.
        /// </summary>
        public readonly TcpClient client;
    }
}
