using System;

namespace guiKernel2.src.Actions
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
