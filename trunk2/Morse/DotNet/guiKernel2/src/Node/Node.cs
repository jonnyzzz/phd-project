using System;
using MorseKernel2;

namespace guiKernel2.src.Node
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	public class Node
	{
		private IResult result;

		public Node(IResult result)
		{
			this.result = result;
		}

		public IAction[] NextActionsDynamic
		{
			get
			{
				return new IAction[0];
			}
		}

		public IAction[] NextActionsStatic
		{
			get
			{
				return new IAction[0];
			}
		}

		public IResult Result
		{
			get
			{
				return result;
			}
		}
	}
}
