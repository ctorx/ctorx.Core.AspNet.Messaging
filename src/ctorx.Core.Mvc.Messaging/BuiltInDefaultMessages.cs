using System;

namespace ctorx.Core.Mvc.Messaging
{
    public class BuiltInDefaultMessages : IDefaultMessages
    {        
        /// <summary>
        /// Gets the default success message
        /// </summary>
        public string DefaultSuccessMessage => "The operation completed sucessfully";

        /// <summary>
        /// Gets the default error message
        /// </summary>
        public string DefaultErrorMessage => "Uh oh, something bad happened.  Please try again.";
    }
}