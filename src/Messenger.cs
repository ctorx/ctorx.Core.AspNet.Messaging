using System.Collections.Generic;
using System.Linq;

namespace ctorx.Core.AspNet.Messaging
{
    public sealed class Messenger
    {
        readonly InMemoryMessageStore InMemoryMessageStore;
        readonly InCookieMessageStore InCookieMessageStore;

        public Messenger(InMemoryMessageStore inMemoryMessageStore, 
            InCookieMessageStore inCookieMessageStore)
        {
            this.InMemoryMessageStore = inMemoryMessageStore;
            this.InCookieMessageStore = inCookieMessageStore;
        }

        /// <summary>
        /// Creates and appends a message
        /// </summary>
        void CreateAndAppendMessage(MessageType type, string messageText, string? caption)
        {
            var message = MessageFactory.Make(type, messageText, caption);           
            this.InMemoryMessageStore.AddMessage(message); 
        }

        /// <summary>
        /// Creates and forwards a message
        /// </summary>
        void CreateAndForwardMessage(MessageType type, string messageText, string? caption)
        {
            var message = MessageFactory.Make(type, messageText, caption);
            this.InCookieMessageStore.AddMessage(message);
        }

        /// <summary>
        /// Gets messages for display
        /// </summary>
        public IList<Message> GetMessages()
        {
            return this.InMemoryMessageStore.GetMessages()
                .Concat(this.InCookieMessageStore.GetMessages())
                .ToList();
        }

        /// <summary>
        /// Appends a message
        /// </summary>
        public void Append(MessageType messageType, string messageText, string? caption = null)
        {
            this.CreateAndAppendMessage(messageType, messageText, caption);
        }

        /// <summary>
        /// Appends an info message
        /// </summary>
        public void AppendInfo(string messageText, string? caption = null)
        {
            this.CreateAndAppendMessage(MessageType.Info, messageText, caption);
        }
        
        /// <summary>
        /// Appends a Warning message
        /// </summary>
        public void AppendWarning(string messageText, string? caption = null)
        {
            this.CreateAndAppendMessage(MessageType.Warn, messageText, caption);
        }
        
        /// <summary>
        /// Appends an Success message
        /// </summary>
        public void AppendSuccess(string messageText, string? caption = null)
        {
            this.CreateAndAppendMessage(MessageType.Success, messageText, caption);
        }
        
        /// <summary>
        /// Appends an Error message
        /// </summary>
        public void AppendError(string messageText, string? caption = null)
        {
            this.CreateAndAppendMessage(MessageType.Error, messageText, caption);
        }
        
        /// <summary>
        /// Forwards a message
        /// </summary>
        public void Forward(MessageType messageType, string messageText, string? caption = null)
        {
            this.CreateAndForwardMessage(messageType, messageText, caption);
        }

        /// <summary>
        /// Forwards an info message
        /// </summary>
        public void ForwardInfo(string messageText, string? caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Info, messageText, caption);
        }
        
        /// <summary>
        /// Forwards a Warning message
        /// </summary>
        public void ForwardWarning(string messageText, string? caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Warn, messageText, caption);
        }
        
        /// <summary>
        /// Forwards an Success message
        /// </summary>
        public void ForwardSuccess(string messageText, string? caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Success, messageText, caption);
        }
        
        /// <summary>
        /// Forwards an Error message
        /// </summary>
        public void ForwardError(string messageText, string? caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Error, messageText, caption);
        }
    }
}