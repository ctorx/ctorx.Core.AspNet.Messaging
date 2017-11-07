namespace ctorx.Core.Mvc.Messaging
{
    public interface IDefaultMessages
    {
        /// <summary>
        /// Gets the default success message
        /// </summary>
        string DefaultSuccessMessage { get; }

        /// <summary>
        /// Gets the default error message
        /// </summary>
        string DefaultErrorMessage { get; }
    }
}