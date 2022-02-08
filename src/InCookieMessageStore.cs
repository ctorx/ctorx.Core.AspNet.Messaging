using System.Collections.Generic;
using ctorx.Core.AspNet.Messaging.Options;
using ctorx.Core.Mvc.Cookies;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ctorx.Core.AspNet.Messaging
{
    public sealed class InCookieMessageStore : IMessageStore
    {
        readonly ICookieManager CookieManager;
        readonly MessagingOptions MessagingOptions;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public InCookieMessageStore(ICookieManager cookieManager, IOptions<MessagingOptions> messagingOptionsProvider)
        {
            this.MessagingOptions = messagingOptionsProvider.Value;
            this.CookieManager = cookieManager;
        }

        /// <summary>
        /// Adds a message to the message store
        /// </summary>
        public void AddMessage(Message message)
        {
            var messages = this.GetMessagesFromCookie();
            messages.Add(message);
            this.SetMessagesInCookie(messages);
        }

        /// <summary>
        /// Gets messages in the message store
        /// </summary>
        public IList<Message> GetMessages()
        {
            var messages = this.GetMessagesFromCookie();
            this.CookieManager.Delete(this.MessagingOptions.CookieKey);
            return messages;
        }

        /// <summary>
        /// Gets the messages from the cookie
        /// </summary>
        IList<Message> GetMessagesFromCookie()
        {
            var cookieValue = this.CookieManager.Get(this.MessagingOptions.CookieKey);

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                return new List<Message>();
            }

            return JsonConvert.DeserializeObject<IList<Message>>(cookieValue, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
        }

        /// <summary>
        /// Sets the messages in the cookie
        /// </summary>
        void SetMessagesInCookie(IList<Message> messages)
        {
            var serialized = JsonConvert.SerializeObject(messages, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
            this.CookieManager.Set(this.MessagingOptions.CookieKey, serialized);
        }
    }
}