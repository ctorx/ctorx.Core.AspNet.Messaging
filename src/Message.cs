namespace ctorx.Core.Mvc.Messaging
{
    public abstract class AbstractMessage : IMessage
	{
        /// <summary>
        /// Gets or sets the message severity
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Gets or sets the Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the message text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the IsDismissable
        /// </summary>
        public bool IsDismissable { get; set; }

        /// <summary>
		/// ctor the Mighty
		/// </summary>
		protected AbstractMessage(MessageType type)
		{
			this.Type = type;
		}

        /// <summary>
        /// ctor the Mighty
        /// </summary>
        protected AbstractMessage(MessageType type, string text, string caption)
        {
            this.IsDismissable = true;

            this.Type = type;
            this.Text = text;
            this.Caption = caption;
        }
    }

    public class SuccessMessage : AbstractMessage
    {
        public SuccessMessage() : base(MessageType.Success, "Your changes have been saved.", "Success") { }
        public SuccessMessage(string text) : base(MessageType.Success, text, "Success") { }
        public SuccessMessage(string text, string caption) : base(MessageType.Success, text, caption) { }
    }

    public class InfoMessage : AbstractMessage
    {
        public InfoMessage() : base(MessageType.Info) { }
        public InfoMessage(string text) : base(MessageType.Info, text, "FYI") { }
        public InfoMessage(string text, string caption) : base(MessageType.Info, text, caption) { }
    }

    public class WarnMessage : AbstractMessage
    {
        public WarnMessage() : base(MessageType.Warn) { }
        public WarnMessage(string text) : base(MessageType.Warn, text, "Warning") { }
        public WarnMessage(string text, string caption) : base(MessageType.Warn, text, caption) { }
    }

    public class ErrorMessage : AbstractMessage
    {
        public ErrorMessage() : base(MessageType.Error, "We're sorry, an unexpected error has occurred. The error has been forwarded to Student Lap Tracker Support.", "Error") { }
        public ErrorMessage(string text) : base(MessageType.Error, text, "Error") { }
        public ErrorMessage(string text, string caption) : base(MessageType.Error, text, caption) { }
    }
}