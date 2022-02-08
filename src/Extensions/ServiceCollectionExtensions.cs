using System;
using ctorx.Core.AspNet.Cookies.Extensions;
using ctorx.Core.AspNet.Messaging.Options;
using Microsoft.Extensions.DependencyInjection;

namespace ctorx.Core.AspNet.Messaging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Messaging services
        /// </summary>
        public static MessagingOptionsBuilder AddMessaging(this IServiceCollection services, Action<MessagingOptions>? options = null)
        {
            services.Configure(options ?? MessagingOptions.Default);

            services.AddCookieManagement();

            services.AddScoped<Messenger, Messenger>();
            services.AddScoped<InMemoryMessageStore>();
            services.AddScoped<InCookieMessageStore>();

            return new MessagingOptionsBuilder(services);
        }
    }
}