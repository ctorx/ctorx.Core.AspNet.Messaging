using System.Collections.Generic;

namespace ctorx.Core.Mvc.Messaging
{
	public interface IMessageStore
	{
		/// <summary>
		/// Adds a message to the message store
		/// </summary>
		void AddMessage(IMessage message);

		/// <summary>
		/// Gets messages in the message store
		/// </summary>
		IList<IMessage> GetMessages();
	}
}