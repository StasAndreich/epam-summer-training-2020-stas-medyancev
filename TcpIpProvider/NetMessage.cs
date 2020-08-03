using System;

namespace TcpIpProvider
{
    /// <summary>
    /// Defines a network message.
    /// </summary>
    public class NetMessage
    {
        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="timeStamp"></param>
        public NetMessage(string data, DateTime timeStamp)
        {
            this.Data = data;
            this.TimeStamp = timeStamp;
        }

        /// <summary>
        /// Message data.
        /// </summary>
        public string Data { get; }
        /// <summary>
        /// Message time stamp when
        /// it has been received.
        /// </summary>
        public DateTime TimeStamp { get; }
    }
}
