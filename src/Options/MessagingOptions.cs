using System;

namespace ctorx.Core.AspNet.Messaging.Options
{
    public sealed class MessagingOptions
    {
        const string DefaultCookieKey = "fwdmsg";

        /// <summary>
        /// Gets or sets the CookieKey
        /// </summary>
        public string CookieKey { get; set; } = DefaultCookieKey;

        /// <summary>
        /// Gets or sets the DefaultErrorMessage property
        /// </summary>
        public string? DefaultErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the DefaultErrorCaption property
        /// </summary>
        public string? DefaultErrorCaption { get; set; }

        /// <summary>
        /// Gets or sets the DefaultSuccessMessage property
        /// </summary>
        public string? DefaultSuccessMessage { get; set; }

        /// <summary>
        /// Gets or sets the DefaultSuccessCaption property
        /// </summary>
        public string? DefaultSuccessCaption { get; set; }

        public static Action<MessagingOptions> Default = options =>
        {
            options.CookieKey = DefaultCookieKey;
        };
    }
}