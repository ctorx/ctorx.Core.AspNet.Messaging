namespace ctorx.Core.Mvc.Messaging
{
	public interface IMessage
	{
		/// <summary>
		/// Gets the type of message
		/// </summary>
		MessageType Type { get; }

	    /// <summary>
	    /// Gets or sets the Caption
	    /// </summary>
	    string Caption { get; set; }

		/// <summary>
		/// Gets the message text
		/// </summary>
		string Text { get; set; }

        /// <summary>
        /// Gets or sets the IsDismissable
        /// </summary>
        bool IsDismissable { get; set; }
	}
}