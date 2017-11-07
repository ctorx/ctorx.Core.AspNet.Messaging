using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace ctorx.Core.Mvc.Messaging
{
    public class DefaultMesenger : IMessenger
    {
        readonly IMessageFactory MessageFactory;
        readonly InMemoryMessageStore InMemoryMessageStore;
        readonly InCookieMessageStore InCookieMessageStore;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public DefaultMesenger(IMessageFactory messageFactory, InMemoryMessageStore inMemoryMessageStore, 
            InCookieMessageStore inCookieMessageStore)
        {
            this.MessageFactory = messageFactory;
            this.InMemoryMessageStore = inMemoryMessageStore;
            this.InCookieMessageStore = inCookieMessageStore;
        }

        /// <summary>
        /// Creates and appends a message
        /// </summary>
        void CreateAndAppendMesage(MessageType type, string messageText, string caption)
        {
            var message = this.MessageFactory.Make(type, messageText, caption);           
            this.InMemoryMessageStore.AddMessage(message); 
        }

        /// <summary>
        /// Creates and forwards a message
        /// </summary>
        void CreateAndForwardMessage(MessageType type, string messageText, string caption)
        {
            var message = this.MessageFactory.Make(type, messageText, caption);
            this.InCookieMessageStore.AddMessage(message);
        }

        /// <summary>
        /// Gets messages for display
        /// </summary>
        public IList<IMessage> GetMessages()
        {
            return this.InMemoryMessageStore.GetMessages()
                .Concat(this.InCookieMessageStore.GetMessages() ?? new List<IMessage>())
                .ToList();
        }

        /// <summary>
        /// Appends an info message
        /// </summary>
        public void AppendInfo(string messageText, string caption = null)
        {
            this.CreateAndAppendMesage(MessageType.Info, messageText, caption);
        }
        
        /// <summary>
        /// Appends a Warning message
        /// </summary>
        public void AppendWarning(string messageText, string caption = null)
        {
            this.CreateAndAppendMesage(MessageType.Warn, messageText, caption);
        }
        
        /// <summary>
        /// Appends an Success message
        /// </summary>
        public void AppendSuccess(string messageText = null, string caption = null)
        {
            this.CreateAndAppendMesage(MessageType.Success, messageText, caption);
        }
        
        /// <summary>
        /// Appends an Error message
        /// </summary>
        public void AppendError(string messageText = null, string caption = null)
        {
            this.CreateAndAppendMesage(MessageType.Error, messageText, caption);
        }
        
        /// <summary>
        /// Forwards an info message
        /// </summary>
        public void ForwardInfo(string messageText, string caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Info, messageText, caption);
        }
        
        /// <summary>
        /// Forwards a Warning message
        /// </summary>
        public void ForwardWarning(string messageText, string caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Warn, messageText, caption);
        }
        
        /// <summary>
        /// Forwards an Success message
        /// </summary>
        public void ForwardSuccess(string messageText = null, string caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Success, messageText, caption);
        }
        
        /// <summary>
        /// Forwards an Error message
        /// </summary>
        public void ForwardError(string messageText = null, string caption = null)
        {
            this.CreateAndForwardMessage(MessageType.Error, messageText, caption);
        }        
    }
}