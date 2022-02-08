using System;

namespace ctorx.Core.AspNet.Messaging
{
    public static class MessageFactory
    {
        /// <summary>
        /// Makes a message
        /// </summary>
        public static Message Make(MessageType type, string messageText, string? caption = null)
        {
            if (string.IsNullOrWhiteSpace(messageText))
            {
                if ((type & (MessageType.Info | MessageType.Warn)) > 0)
                {
                    throw new ArgumentNullException(nameof(messageText));
                }
            }

            switch (type)
            {
                case MessageType.Info:
                    return new InfoMessage(messageText, caption);
                case MessageType.Warn:
                    return new WarnMessage(messageText, caption);
                case MessageType.Success:
                    return new SuccessMessage(messageText, caption);
                case MessageType.Error:
                    return new ErrorMessage(messageText, caption);
                default:
                    throw new NotImplementedException("Message type not supported");
            }

        }
    }
}