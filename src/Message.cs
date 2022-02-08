namespace ctorx.Core.AspNet.Messaging
{
    public abstract class Message
	{
        /// <summary>
        /// Gets or sets the message severity
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Gets or sets the Caption
        /// </summary>
        public string? Caption { get; }

        /// <summary>
        /// Gets or sets the message text
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets or sets the IsDismissible
        /// </summary>
        public bool IsDismissible { get; }

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        protected Message(MessageType type, string text, string? caption = null)
        {
            this.IsDismissible = true;

            this.Type = type;
            this.Text = text;
            this.Caption = caption;
        }
    }

    public sealed class SuccessMessage : Message
    {
        public SuccessMessage(string text, string? caption) : base(MessageType.Success, text, caption) { }
    }

    public sealed class InfoMessage : Message
    {
        public InfoMessage(string text, string? caption) : base(MessageType.Info, text, caption) { }
    }

    public sealed class WarnMessage : Message
    {
        public WarnMessage(string text, string? caption) : base(MessageType.Warn, text, caption) { }
    }

    public sealed class ErrorMessage : Message
    {
        public ErrorMessage(string text, string? caption) : base(MessageType.Error, text, caption) { }
    }
}