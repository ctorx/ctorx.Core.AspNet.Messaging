using System;

namespace ctorx.Core.Mvc.Messaging
{
    public class DefaultMessageFactory : IMessageFactory
    {
        readonly IDefaultMessages DefaultMessages;

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        public DefaultMessageFactory(IDefaultMessages defaultMessages)
        {
            this.DefaultMessages = defaultMessages;
        }

        /// <summary>
        /// Makes a message
        /// </summary>
        public IMessage Make(MessageType type, string messageText, string caption = null)
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
                    return new SuccessMessage(messageText ?? this.DefaultMessages.DefaultSuccessMessage, caption);
                case MessageType.Error:
                    return new ErrorMessage(messageText ?? this.DefaultMessages.DefaultErrorMessage, caption);
                default:
                    throw new NotImplementedException();
            }

        }
    }
}