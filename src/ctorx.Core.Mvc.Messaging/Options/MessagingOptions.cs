using System;

namespace ctorx.Core.Mvc.Messaging.Options
{
    public class MessagingOptions
    {
        /// <summary>
        /// Gets or sets the CookieKey
        /// </summary>
        public string CookieKey { get; set; }

        public static Action<MessagingOptions> Default = options =>
        {
            options.CookieKey = "fwdmsg";
        };
    }
}