
using System;

namespace ctorx.Core.Mvc.Messaging
{
	[Flags]
	public enum MessageType
	{
		Error = 1,
		Warn = 2,
		Info = 4,
		Success = 8
	}
}