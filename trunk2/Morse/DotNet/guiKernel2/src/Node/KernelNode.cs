using System;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;
using MorseKernel2;

namespace guiKernel2.src.Node
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	public class KernelNode
	{
		private IResult result;

		public KernelNode(IResultBase result)
		{
			this.result = result as IResult;
		}

		public ActionWrapper[] NextActions
		{
			get
			{
				return NextActionFactory.Instance.NextAction(this);
			}
		}

		public IResult Result
		{
			get
			{
				return result;
			}
		}

		public string Caption
		{
			get
			{
				if (result is IGraphResult)
				{
					IGraphResult graphResult = (IGraphResult)result;
					IGraphInfo info = graphResult.GetGraphInfo();

					return string.Format("Graph node: {0} nodes, {1} edges", info.GetNodes(), info.GetEdges());
				} else
				{
					return "Unknown IResult";
				}
			}
		}
	}
}
