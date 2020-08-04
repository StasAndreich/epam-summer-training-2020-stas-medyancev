using System.Collections.Generic;
using System.Text;
using TcpIpProvider;

namespace ServerServices
{
    /// <summary>
    /// Server service that stores 
    /// a message history.
    /// </summary>
    public class MessagesHistory
    {
        private Dictionary<NetClient, List<NetMessage>> messages =
            new Dictionary<NetClient, List<NetMessage>>();

        /// <summary>
        /// Ctor that creates a history
        /// on a specified server.
        /// </summary>
        /// <param name="server"></param>
        public MessagesHistory(NetServer server)
        {
            server?.SubscribeToMessageReceived(
                (sender, e) => Add(e.client, e.message));
        }

        /// <summary>
        /// Adds a new message in the history.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public void Add(NetClient client, NetMessage message)
        {
            if (!messages.ContainsKey(client))
            {
                // Add new Key - Value pair.
                var newList = new List<NetMessage>();
                newList.Add(message);
                messages.Add(client, newList);
            }
            else
            {
                // Add new message to existing client.
                messages.TryGetValue(client, out List<NetMessage> list);
                list.Add(message);
            }
        }

        /// <summary>
        /// Removes all client's message history.
        /// </summary>
        /// <param name="client"></param>
        public void Remove(NetClient client)
        {
            messages.Remove(client);
        }

        /// <summary>
        /// Returns a messages list of a specified
        /// client. Otherwise returns null.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public List<NetMessage> this[NetClient client]
        {
            get
            {
                if (messages.TryGetValue(client, out List<NetMessage> list))
                    return list;
                else
                    return null;
            }
        }

        /// <summary>
        /// Check the equality of this message history
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var history = (MessagesHistory)obj;

            return this.messages.Equals(history.messages);
        }

        /// <summary>
        /// Returns a hash-code for a message history obj.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return messages.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// messages for every client.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var pair in messages)
            {
                result.Append($"[{pair.Key}]:\n");
                var mesList = this[pair.Key];

                foreach (var mes in mesList)
                {
                    result.Append($"\t- {mes};\n");
                }
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
