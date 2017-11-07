namespace ctorx.Core.Mvc.Messaging
{
    public interface IMessageFactory
    {
        /// <summary>
        /// Makes a message
        /// </summary>
        IMessage Make(MessageType type, string message, string caption = null);
    }
}