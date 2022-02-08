using System.Collections.Generic;

namespace ctorx.Core.AspNet.Messaging
{
	public interface IMessageStore
	{
		/// <summary>
		/// Adds a message to the message store
		/// </summary>
		void AddMessage(Message message);

		/// <summary>
		/// Gets messages in the message store
		/// </summary>
		IList<Message> GetMessages();
	}
}