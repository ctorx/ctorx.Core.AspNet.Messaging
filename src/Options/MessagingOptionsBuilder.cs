using System;
using Microsoft.Extensions.DependencyInjection;

namespace ctorx.Core.Mvc.Messaging.Options
{
    /// <summary>
    /// Used to build Picnic Options fluently
    /// </summary>
    public class MessagingOptionsBuilder
    {
        readonly IServiceCollection Services;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public MessagingOptionsBuilder(IServiceCollection services)
        {
            this.Services = services;
        }        
    }
}