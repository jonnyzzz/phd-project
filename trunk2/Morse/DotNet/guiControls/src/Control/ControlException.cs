using System;

namespace guiControls.Control
{
	/// <summary>
	/// Summary description for ControlException.
	/// </summary>
	public class ControlException : Exception
	{
		public ControlException(string message) : base(message)
		{
		}

		public ControlException()
		{
		}

		public virtual string ErrorDescription
		{
			get
			{
				return Message;
			}
		}

		public virtual string ErrorDescriptionShort
		{
			get
			{
				return Message;
			}
		}
	}
}
