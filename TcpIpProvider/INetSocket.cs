using System;

namespace TcpIpProvider
{
    interface INetSocket
    {
        void ReadMessage();

        void SendMessage();

        //event EventHandler<> OnMessageReceived;
    }
}
