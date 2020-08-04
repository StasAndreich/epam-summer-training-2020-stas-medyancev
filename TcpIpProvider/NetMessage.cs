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
        public NetMessage(string data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Message data.
        /// </summary>
        public string Data { get; }
    }
}
