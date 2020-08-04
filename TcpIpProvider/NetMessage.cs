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

        /// <summary>
        /// Check the equality of this message 
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var mes = (NetMessage)obj;

            return this.Data.Equals(mes.Data);
        }

        /// <summary>
        /// Returns a hash-code for a NetMessage obj.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// message data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data;
        }
    }
}
