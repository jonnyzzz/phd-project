using System;

namespace guiKernel2.Actions
{
	/// <summary>
	/// Summary description for ActionException.
	/// </summary>
	public class ActionException : Exception
	{
		public ActionException( string message) : base(message)
		{
		}
	}
}
