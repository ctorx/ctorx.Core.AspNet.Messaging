using System;

namespace ctorx.Core.AspNet.Messaging.Options
{
    public sealed class MessagingOptions
    {
        const string DefaultCookieKey = "fwdmsg";

        /// <summary>
        /// Gets or sets the CookieKey
        /// </summary>
        public string CookieKey { get; set; }

        public static Action<MessagingOptions> Default = options =>
        {
            options.CookieKey = DefaultCookieKey;
        };

        public MessagingOptions()
        {
            this.CookieKey = DefaultCookieKey;
        }
    }
}