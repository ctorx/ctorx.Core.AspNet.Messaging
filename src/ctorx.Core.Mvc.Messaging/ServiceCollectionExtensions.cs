using System;
using ctorx.Core.Mvc.Cookies;
using ctorx.Core.Mvc.Messaging.Options;
using Microsoft.Extensions.DependencyInjection;

namespace ctorx.Core.Mvc.Messaging
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds messenging services
        /// </summary>
        public static MessagingOptionsBuilder AddMessaging(this IServiceCollection services, Action<MessagingOptions> options = null)
        {
            services.Configure(options ?? MessagingOptions.Default);

            services.AddScoped<ICookieManager, DefaultCookieManager>();
            services.AddScoped<IMessenger, DefaultMesenger>();
            services.AddSingleton<IMessageFactory, DefaultMessageFactory>();
            services.AddScoped<InMemoryMessageStore>();
            services.AddScoped<InCookieMessageStore>();
            services.AddScoped<IDefaultMessages, BuiltInDefaultMessages>();

            return new MessagingOptionsBuilder(services);
        }
    }
}