using System;
using guiControls.Control;

namespace guiControls.Grid
{
	/// <summary>
	/// Summary description for ExGridException.
	/// </summary>
	public class ExGridException : ControlException
	{
		public ExGridException(string message) : base(message)
		{
			this.errorDescShort = Message;
		}

		public ExGridException(string template, params object[] pars) : base(string.Format(template, pars))
		{
			this.errorDescShort = Message;
		}

		private string errorDescShort;

		public override string ErrorDescription
		{
			get { return errorDescShort; }
		}

		public override string ErrorDescriptionShort
		{
			get { return errorDescShort; }
		}
	}
}
