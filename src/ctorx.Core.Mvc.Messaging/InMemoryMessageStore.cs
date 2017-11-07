using System.Collections.Generic;

namespace ctorx.Core.Mvc.Messaging
{
    public class InMemoryMessageStore : IMessageStore
    {
        readonly IList<IMessage> Messages;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public InMemoryMessageStore()
        {
            this.Messages = new List<IMessage>();
        }

        /// <summary>
        /// Adds a message to the message store
        /// </summary>
        public void AddMessage(IMessage message)
        {
            this.Messages.Add(message);
        }

        /// <summary>
        /// Gets messages in the message store
        /// </summary>
        public IList<IMessage> GetMessages()
        {
            var forReturn = new List<IMessage>(this.Messages);
            this.Messages.Clear();
            return forReturn;
        }
    }
}