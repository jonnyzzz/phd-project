using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Xml;

namespace guiActions.src.parameters
{
	/// <summary>
	/// Summary description for ParametersControlException.
	/// </summary>
	public class ParametersControlException : Exception
	{
		public ParametersControlException(string message) : base(message)
		{
		}

		public ParametersControlException()
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
