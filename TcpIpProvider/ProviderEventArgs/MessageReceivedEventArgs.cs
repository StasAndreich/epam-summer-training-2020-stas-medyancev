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
        /// with a TcpClient and a formed message.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public MessageReceivedEventArgs(TcpClient client,
                                        NetMessage message)
        {
            this.client = client;
            this.message = message;
        }

        /// <summary>
        /// Stores a TcpClient that sent
        /// received message.
        /// </summary>
        public readonly TcpClient client;
        /// <summary>
        /// Stores a message itself.
        /// </summary>
        public readonly NetMessage message;
    }
}
