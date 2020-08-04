using System;
using System.Collections.Generic;
using System.Net.Sockets;
using TcpIpProvider;

namespace ServerServices
{
    public class MessagesHistory
    {
        public Dictionary<NetClient, List<NetMessage>> messages;

        public MessagesHistory(NetServer server)
        {
            server.SubscribeToReceivedMessages(Add);
        }

        public void Add(NetMessage message)
        {
            messages.Add();
        }
    }
}
