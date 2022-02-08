using System.Collections.Generic;

namespace ctorx.Core.AspNet.Messaging
{
    public sealed class InMemoryMessageStore : IMessageStore
    {
        readonly IList<Message> Messages;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public InMemoryMessageStore()
        {
            this.Messages = new List<Message>();
        }

        /// <summary>
        /// Adds a message to the message store
        /// </summary>
        public void AddMessage(Message message)
        {
            this.Messages.Add(message);
        }

        /// <summary>
        /// Gets messages in the message store
        /// </summary>
        public IList<Message> GetMessages()
        {
            var forReturn = new List<Message>(this.Messages);
            this.Messages.Clear();
            return forReturn;
        }
    }
}