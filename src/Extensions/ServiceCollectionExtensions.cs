using System;
using ctorx.Core.Mvc.Cookies.Extensions;
using ctorx.Core.Mvc.Messaging.Options;
using Microsoft.Extensions.DependencyInjection;

namespace ctorx.Core.Mvc.Messaging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds messenging services
        /// </summary>
        public static MessagingOptionsBuilder AddMessaging(this IServiceCollection services, Action<MessagingOptions> options = null)
        {
            services.Configure(options ?? MessagingOptions.Default);

            services.AddCookieManagement();

            services.AddScoped<IMessenger, DefaultMesenger>();
            services.AddSingleton<IMessageFactory, DefaultMessageFactory>();
            services.AddScoped<InMemoryMessageStore>();
            services.AddScoped<InCookieMessageStore>();
            services.AddScoped<IDefaultMessages, BuiltInDefaultMessages>();

            return new MessagingOptionsBuilder(services);
        }
    }
}