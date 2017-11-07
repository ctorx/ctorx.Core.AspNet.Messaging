using System;
using System.Collections.Generic;

namespace ctorx.Core.Mvc.Messaging
{
    public interface IMessenger
    {
        /// <summary>
        /// Appends an info message
        /// </summary>
        void AppendInfo(string message, string caption = null);
        
        /// <summary>
        /// Appends a Warning message
        /// </summary>
        void AppendWarning(string message, string caption = null);
        
        /// <summary>
        /// Appends an Success message
        /// </summary>
        void AppendSuccess(string message = null, string caption = null);
        
        /// <summary>
        /// Appends an Error message
        /// </summary>
        void AppendError(string message = null, string caption = null);
        
        /// <summary>
        /// Forwards an info message
        /// </summary>
        void ForwardInfo(string message, string caption = null);
        
        /// <summary>
        /// Forwards a Warning message
        /// </summary>
        void ForwardWarning(string message, string caption = null);
        
        /// <summary>
        /// Forwards an Success message
        /// </summary>
        void ForwardSuccess(string message = null, string caption = null);
        
        /// <summary>
        /// Forwards an Error message
        /// </summary>
        void ForwardError(string message = null, string caption = null);
        
        /// <summary>
        /// Gets messages for display
        /// </summary>
        IList<IMessage> GetMessages();
    }    
}