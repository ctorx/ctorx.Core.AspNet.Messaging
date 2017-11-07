using System.Collections.Generic;
using ctorx.Core.Mvc.Cookies;
using Newtonsoft.Json;

namespace ctorx.Core.Mvc.Messaging
{
    public class InCookieMessageStore : IMessageStore
    {
        readonly ICookieManager CookieManager;

        // TODO: make configurable
        string MessageCookieKey = "fwdmsg";

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public InCookieMessageStore(ICookieManager cookieManager)
        {
            this.CookieManager = cookieManager;
        }

        /// <summary>
        /// Adds a message to the message store
        /// </summary>
        public void AddMessage(IMessage message)
        {
            var messages = this.GetMessagesFromCookie() ?? new List<IMessage>();
            messages.Add(message);
            this.SetMessagesInCookie(messages);
        }

        /// <summary>
        /// Gets messages in the message store
        /// </summary>
        public IList<IMessage> GetMessages()
        {
            var messages = this.GetMessagesFromCookie();
            this.CookieManager.Delete(this.MessageCookieKey);
            return messages;
        }

        /// <summary>
        /// Gets the messages from the cookie
        /// </summary>
        IList<IMessage> GetMessagesFromCookie()
        {
            var cookieValue = this.CookieManager.Get(this.MessageCookieKey);

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IList<IMessage>>(cookieValue, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
        }

        /// <summary>
        /// Sets the messages in the cookie
        /// </summary>
        void SetMessagesInCookie(IList<IMessage> messages)
        {
            var serialized = JsonConvert.SerializeObject(messages, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
            this.CookieManager.Set(this.MessageCookieKey, serialized);
        }
    }
}